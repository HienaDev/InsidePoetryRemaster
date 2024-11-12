using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // PHYSICS VARIABLES
    private Rigidbody2D rb;

    // MOVEMENT VARIABLES
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.D;
    [SerializeField] private KeyCode shoot = KeyCode.Space;
    [SerializeField] private float moveSpeed;
    private Vector2 speed;
    private bool canMove;

    // CAMERA
    [SerializeField] private Camera playerCamera;
    public Camera PlayerCamera { get { return playerCamera; } }

    // ANIMATION VARIABLES
    private Animator animator;

    // CHARGING THROW VARIABLES
    [SerializeField] private float chargeSpeedPercent;
    private float chargeThrow;
    private float chargeIncrement;
    private float maxCharge;
    private bool charging;

    // THROWING BALL VARIABLES
        // The ball prefab
    [SerializeField] private GameObject teleportBall;
        // Where we keep the balls so they arent children of the player
    [SerializeField] private GameObject prefabManager;
    public GameObject PrefabManager { get { return prefabManager; } }   
        // Where the ball spawns
    [SerializeField] private GameObject firePoint;
        // The arm's pivot and object
    [SerializeField] private GameObject arm;
        // Force on both axis defined in the editor
    [SerializeField] private float throwForceX;
    [SerializeField] private float throwForceY;
        // Save minimum values in case the player just taps the charge button
    [SerializeField] private float minForceX;
    [SerializeField] private float minForceY;
        // Save current ball so we only have 1 ball active
    private GameObject currentBall;
    private bool canShoot = true;

    // SOUND VARIABLES
        // The sound controller
    private PlayerSounds playerSounds;

    // DEV VARIABLES
    // hold last play position
    private Vector2 posBeforeTP;

    // Start is called before the first frame update
    void Start()
    {
        posBeforeTP = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        speed = Vector2.zero;

        animator = GetComponent<Animator>();

        chargeThrow = 0f;

        maxCharge = 1f;
        chargeIncrement = maxCharge * chargeSpeedPercent;

        charging = false;

        currentBall = null;

        canMove = true;

        playerSounds = GetComponent<PlayerSounds>();
    }

    // Update is called once per frame
    void Update()
    {
        Cheats();

        

        MovePlayer();

        if (canShoot)
            ChargeThrow();

        FlipPlayer();

        UpdateAnimations();


    }

    private void Cheats()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            transform.position = posBeforeTP;
        }
    }
    
    private void MovePlayer()
    {
        speed = new Vector2(0, rb.velocity.y);

        if (!charging && canMove)
        { 
            if (Input.GetKey(right) || Input.GetKey(right))
            {
                speed.x = moveSpeed;
            }

            if (Input.GetKey(left) || Input.GetKey(left))
            {
                speed.x = -moveSpeed;
            }
        }

        rb.velocity = speed;
    }

    private void ThrowBall(float chargeThrow)
    {
        currentBall = Instantiate(teleportBall, firePoint.transform.position, Quaternion.identity, prefabManager.transform);

        currentBall.GetComponent<Rigidbody2D>().velocity = new Vector3( Mathf.Max(minForceX, chargeThrow * throwForceX) * transform.right.x, 
                                                                        Mathf.Max(minForceY, chargeThrow * throwForceY)
                                                                        , 0f);
        posBeforeTP = transform.position;
        canShoot = false;
    }

    private void ChargeThrow()
    {

        if (Input.GetKey(shoot))
        {

            arm.SetActive(true);
            if (chargeThrow < maxCharge)
            {
                chargeThrow += chargeIncrement * Time.deltaTime;
                arm.transform.Rotate(new Vector3(0f, 0f, 45f) * Time.deltaTime);
            }

            charging = true;
        }

        if (Input.GetKeyUp(shoot))
        {
            ThrowBall(chargeThrow);
            ResetArmRotation();
            arm.SetActive(false);
            chargeThrow = 0f;
            charging = false;
        }
    }
    private void UpdateAnimations()
    {
        animator.SetFloat("MoveSpeedX", Mathf.Abs(rb.velocity.x));
        animator.SetBool("Charging", charging);
    }

    private void ResetArmRotation()
    {
        if (transform.right.x < 0)
            arm.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else if (transform.right.x > 0)
            arm.transform.rotation = Quaternion.identity;
    }

    private void FlipPlayer()
    {
        if (rb.velocity.x < 0 && transform.right.x > 0)
        { 
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            
        }
        else if (rb.velocity.x > 0 && transform.right.x < 0)
        { 
            transform.rotation = Quaternion.identity;
            
        }

        // https://answers.unity.com/questions/640162/detect-mouse-in-right-side-or-left-side-for-player.html
        //if (Input.GetMouseButton(1))
        //{
        //    var playerScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //    if (Input.mousePosition.x < playerScreenPoint.x)
        //        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        //    else
        //        transform.rotation = Quaternion.identity;
        //}
        //Debug.Log($"Input.mousePosition: {(Input.mousePosition.x - 615) / 2},{(Input.mousePosition.y - 360) / 2}");
        //Debug.Log($"gameObject.transform.position: {gameObject.transform.position}");
    }


    public void UpdatePosition(Vector3 position)
    {
        canShoot = true;
        transform.position = position;
        playerSounds.PlayTeleportSound();
        GetComponent<SpriteRenderer>().enabled = true; 
        animator.SetTrigger("Teleport");
    }

    public void ActivateMove() => canMove = true;

    public void DeactivateMove() => canMove = false;

}
