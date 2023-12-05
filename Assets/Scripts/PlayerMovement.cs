using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    private Vector2 speed;
    private Animator animator;

    private float chargeThrow;
    [SerializeField] private float chargeSpeedPercent;
    private float chargeIncrement;
    private float maxCharge;

    private bool charging;

    [SerializeField] private GameObject teleportBall;
    private GameObject prefabManager;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject arm;
    [SerializeField] private float throwForceX;
    [SerializeField] private float minForceX;
    [SerializeField] private float throwForceY;
    [SerializeField] private float minForceY;

    private GameObject currentBall;

    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = Vector2.zero;

        animator = GetComponent<Animator>();

        chargeThrow = 0f;

        maxCharge = 1f;
        chargeIncrement = maxCharge * chargeSpeedPercent;

        charging = false;

        prefabManager = FindObjectOfType<PrefabManager>().gameObject;

        currentBall = null;

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {

        MovePlayer();

        if (currentBall == null)
            ChargeThrow();

        FlipPlayer();

        UpdateAnimations();


    }
    
    private void MovePlayer()
    {
        speed = new Vector2(0, rb.velocity.y);

        if (!charging && canMove)
        { 
            if (Input.GetKey(KeyCode.D))
            {
                speed.x = moveSpeed;
            }

            if (Input.GetKey(KeyCode.A))
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
    }

    private void ChargeThrow()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            arm.SetActive(true);
            if (chargeThrow < maxCharge)
            {
                chargeThrow += chargeIncrement * Time.deltaTime;
                arm.transform.Rotate(new Vector3(0f, 0f, 45f) * Time.deltaTime);
            }

            charging = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
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
        transform.position = position;
        animator.SetTrigger("Teleport");
    }

    public void ActivateMove() => canMove = true;

    public void DeactivateMove() => canMove = false;

}
