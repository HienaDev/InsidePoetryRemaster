using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBack : MonoBehaviour
{

    [SerializeField] private Transform teleportTo;

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
        Vector2 pos = transform.position;
        Debug.Log(collision.ClosestPoint(collision.gameObject.transform.position) - pos);
        Vector2 teleportToPos = teleportTo.position;
        collision.gameObject.transform.position = teleportToPos + collision.ClosestPoint(collision.gameObject.transform.position) - pos;
    }
}
