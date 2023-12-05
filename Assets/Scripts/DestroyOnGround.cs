using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGround : MonoBehaviour
{

    [SerializeField] private LayerMask floorLayer;




    private void OnTriggerEnter2D(Collider2D collision)
    {

        int x = 1 << collision.gameObject.layer;

        if (x == floorLayer.value)
        { 

        GetComponent<Collider2D>().enabled = false;

        GetComponentInParent<PrefabManager>().UpdatePlayerPosition(transform.position);

        Destroy(gameObject);
        }
    }
}
