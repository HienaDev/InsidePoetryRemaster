using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMultiplayer : MonoBehaviour
{

    [SerializeField] private GameObject player2;

    [SerializeField] private GameObject player2Controls;

    [SerializeField] private GameObject player2Background;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L))
        {
            ActivatePlayer2();
        }
    }

    public void ActivatePlayer2()
    {
        player2.SetActive(!player2.activeSelf);
        player2Controls.SetActive(!player2Controls.activeSelf);
        player2Background.SetActive(!player2Background.activeSelf);
    }
}
