using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravityWithSpeed : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private float extraGravity;
    private float gravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0f)
        {
            rb.gravityScale = extraGravity;
        }
        else
            rb.gravityScale = gravity;
    }
}
