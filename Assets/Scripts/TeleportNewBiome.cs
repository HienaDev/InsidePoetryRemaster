using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportNewBiome : MonoBehaviour
{

    [SerializeField] private Transform newBiomeTeleportRoot;
    [SerializeField] private Transform pivotRotation;
    [SerializeField] private GameObject ballAnimation;
    private Sprite ballSprite;
    private GameObject ball;
    private Animator animator;
    [SerializeField] private TeleportToJungle teleportScript;
    private GameObject prefabManager;

    [SerializeField] private bool endingPortal;
    [SerializeField] private UnityEvent eventToTrigger;

    [SerializeField] private Sprite alienSprite;
    private bool alien = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        prefabManager = null;

        ballAnimation.GetComponent<SpriteRenderer>().enabled = false;

        ballSprite = ballAnimation.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject;//.transform.position = newBiomeTeleportRoot.position;



        StartCoroutine(TravelToPoint());
    }

    private IEnumerator TravelToPoint()
    {
        float lerpValue = 0f;
        Vector3 initialPosition = ball.transform.position;

        Debug.Log("inital positin: " + initialPosition);
        Debug.Log("Final position: " + pivotRotation.position);






        while (lerpValue < 1)
        {
            lerpValue += Time.deltaTime;
            ball.transform.position = Vector3.Lerp(initialPosition, pivotRotation.position, lerpValue);
            ball.transform.Rotate(0f, 0f, 1f);
            yield return null;
        }

        prefabManager = ball.transform.parent.gameObject;

        yield return null;
        Destroy(ball);
        //Instantiate(ballAnimation, pivotRotation);


        //if (alien)
        //    ballAnimation.GetComponent<SpriteRenderer>().sprite = ball;
        //else
        //    ballAnimation.GetComponent<SpriteRenderer>().sprite = ballSprite;


        //ballAnimation.SetActive(true);



        animator.SetTrigger("Portal");


    }

    public void Teleport()
    {
        if (!endingPortal)
            teleportScript.Teleport(prefabManager);

        prefabManager = null;

        ballAnimation.GetComponent<SpriteRenderer>().enabled = false;

        if (endingPortal) { eventToTrigger.Invoke(); }


        alien = false;
    }


}
