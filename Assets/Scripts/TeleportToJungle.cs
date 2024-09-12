using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToJungle : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Vector2 speed;
    [SerializeField] private GameObject prefabParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Teleport(GameObject playerPrefabManager)
    {
        GameObject ball;
        ball = Instantiate(ballPrefab, playerPrefabManager.transform);
        ball.transform.position = transform.position;
        Debug.Log("before" + ball.GetComponent<Rigidbody2D>().velocity);
        ball.GetComponent<Rigidbody2D>().velocity = speed;
        Debug.Log("after " + ball.GetComponent<Rigidbody2D>().velocity);
    }
}
