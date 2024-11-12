using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravityZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        Debug.Log(collision.name);

        if (rb != null)
        {
            Debug.Log("rb not null");

            if (rb.gravityScale > 0)
            {

                rb.gravityScale *= -1;
            }
                
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Debug.Log("rb not null");

            if (rb.gravityScale < 0)
            {

                rb.gravityScale *= -1;
            }

        }
    }
}
