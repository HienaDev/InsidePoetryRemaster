using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        GetComponent<Collider2D>().enabled = false;

        GetComponentInParent<PrefabManager>().UpdatePlayerPosition(transform.position);

        Destroy(gameObject);
    }
}
