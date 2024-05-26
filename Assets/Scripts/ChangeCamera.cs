using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private LayerMask ballMask;
    [SerializeField] private LayerMask headMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int x = 1 << collision.gameObject.layer;

        // If we contact with the layer we update the player's position and destroy the ball
        if (x == headMask.value)
        {
            Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10f);

        }
        else if (x == ballMask.value)
        {
            Camera.main.transform.position = new Vector3( gameObject.transform.position.x, gameObject.transform.position.y, -10f);

        }

    }

    
}
