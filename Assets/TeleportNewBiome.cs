using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportNewBiome : MonoBehaviour
{

    [SerializeField] private Transform newBiomeTeleportRoot;
    [SerializeField] private Transform pivotRotation;
    [SerializeField] private GameObject ballAnimation;
    private GameObject ball;
    private Animator animator;
    [SerializeField] private TeleportToJungle teleportScript;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject;//.transform.position = newBiomeTeleportRoot.position;
        ball.GetComponent<Rigidbody2D>().isKinematic = true;

        StartCoroutine(TravelToPoint());
    }

    private IEnumerator TravelToPoint()
    {
        float lerpValue = 0f;
        Vector3 initialPosition = ball.transform.position;

        Debug.Log("inital positin: " + initialPosition);
        Debug.Log("Final position: " + pivotRotation.position);

        while(lerpValue < 1)
        {
            lerpValue += Time.deltaTime;
            ball.transform.position = Vector3.Lerp(initialPosition, pivotRotation.position, lerpValue);
            yield return null;
        }

        Destroy(ball);
        ballAnimation.SetActive(true);
        animator.SetTrigger("Portal");
    }

    public void Teleport() => teleportScript.Teleport();
}
