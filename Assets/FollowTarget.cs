using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private bool X = false;
    [SerializeField] private bool Y = true;

    static FollowTarget instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(X)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, -10f);
        }

        if (Y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, -10f);
        }
    }

    public void ChangeTarget(Transform target) => this.target = target; 
}
