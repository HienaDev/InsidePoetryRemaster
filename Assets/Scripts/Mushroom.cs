using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private Vector2 speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.GetComponent<ChangeGravityWithSpeed>() != null)
        {
            Debug.Log("collision with ball");
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = speed;
        }
    }
}
