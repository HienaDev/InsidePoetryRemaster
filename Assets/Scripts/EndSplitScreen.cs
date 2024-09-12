using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSplitScreen : MonoBehaviour
{

    private CameraManager camManager;

    // Start is called before the first frame update
    void Start()
    {
        camManager = GetComponentInParent<CameraManager>();
    }


    public void EndSplit() => camManager.EndSplitScreen();
}
