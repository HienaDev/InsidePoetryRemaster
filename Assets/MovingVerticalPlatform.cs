using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingVerticalPlatform : MonoBehaviour
{

    [SerializeField] private float movSpeed = 10f;
    [SerializeField] private Vector2 positionA;
    [SerializeField] private Vector2 positionB;
    private int index = 0;
    private Rigidbody2D rb;
    private Vector2 velocity;
    private bool flipped = false;

    private float lerpValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(0, movSpeed);

        positionA = (Vector2)transform.position + positionA;
        positionB = (Vector2)transform.position + positionB;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    private void FixedUpdate()
    {

        if (transform.position.y < positionA.y && !flipped)
        {
            velocity *= -1;
            flipped = true;

        }
        if (transform.position.y > positionB.y && !flipped)
        {
            velocity *= -1;
            flipped = true;
        }
        if (flipped)
        {
            rb.velocity = velocity;
            flipped = false;
        }
    }


    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(positionA + (Vector2)transform.position, 3f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(positionB + (Vector2)transform.position, 3f);
    }
}
