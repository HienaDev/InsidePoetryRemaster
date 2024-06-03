using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{

    [SerializeField] private Transform lastJumpPosition;
    [SerializeField] private Transform firstJumpJungle;
    [SerializeField] private Transform catJungle;
    [SerializeField] private Transform finalJump;
    [SerializeField] private Transform finishDebug;
    [SerializeField] private EndGame endScript;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.C) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = lastJumpPosition.position;
            endScript.ActivateCheater();
        }

        if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.C) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.position = firstJumpJungle.position;
            endScript.ActivateCheater();
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = firstJumpJungle.position;
            endScript.ActivateCheater();
        }

        if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.C) && Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.position = catJungle.position;
            endScript.ActivateCheater();
        }

        if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.C) && Input.GetKeyDown(KeyCode.Alpha4))
        {
            transform.position = finalJump.position;
            endScript.ActivateCheater();
        }

        if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.C) && Input.GetKeyDown(KeyCode.Alpha9))
        {
            transform.position = finishDebug.position;
            endScript.ActivateCheater();
        }
    }


}
