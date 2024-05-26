using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public void UpdatePosition(Vector3 position) => transform.position = position;
}
