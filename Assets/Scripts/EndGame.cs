using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    [SerializeField] private Timer timer;
    [SerializeField] private GameObject cheated;
    private bool cheater;

    // Start is called before the first frame update
    void Start()
    {
        cheater = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        if (cheater)
            cheated.SetActive(true);
        else
            timer.EndGame();
    }

    public void ActivateCheater() => cheater = true;
}
