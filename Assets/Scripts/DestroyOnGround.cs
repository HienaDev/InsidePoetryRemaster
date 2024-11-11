using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGround : MonoBehaviour
{

    // Layer where the ball gets destroyed and teleports the alien to
    [SerializeField] private LayerMask floorLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Convert the collision object layer
        int x = 1 << collision.gameObject.layer;

        // If we contact with the layer we update the player's position and destroy the ball
        if (x == floorLayer.value)
        {

            GetComponentInParent<PrefabManager>().UpdatePlayerPosition(transform.position);

            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}







