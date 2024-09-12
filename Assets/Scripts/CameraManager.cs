using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform camera1;
    [SerializeField] private Transform camera2;

    [SerializeField] private GameObject singleCamera;
    [SerializeField] private GameObject splitScreen;

    [SerializeField] private GameObject cameraNoMultiplayer;

    [SerializeField] private Animator animator;

    private bool splitScreenToggle = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L)) 
        {
            ActivateMulitplayerCheat();
        }
    }

    private void FixedUpdate()
    {
        if (camera1.transform.position != camera2.transform.position && !splitScreenToggle)
        {
            //TriggerSplitScreen();
            animator.SetTrigger("OpenScreen");
            animator.ResetTrigger("CloseScreen");
            splitScreenToggle = true;
        }
        else if (camera1.transform.position == camera2.transform.position && splitScreenToggle)
        {
            animator.SetTrigger("CloseScreen");
            animator.ResetTrigger("OpenScreen");
            splitScreenToggle = false;
        }
    }

    public void ActivateMulitplayerCheat()
    {
        animator.SetBool("ActiveMP", !animator.GetBool("ActiveMP"));
        splitScreenToggle = !splitScreenToggle;
    }

    public void TriggerSplitScreen()
    {
        splitScreen.SetActive(true);
        singleCamera.SetActive(false);
    }

    public void EndSplitScreen()
    {
        splitScreen.SetActive(false);
        singleCamera.SetActive(true);
        Camera.main.transform.position = camera1.transform.position;
        cameraNoMultiplayer.transform.position = camera1.transform.position;
    }
}
