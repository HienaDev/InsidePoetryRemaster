using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{

    [SerializeField] private PlayerMovement player;


    public void UpdatePlayerPosition(Vector3 position)
    {
        player.UpdatePosition(new Vector3 (position.x, position.y + 20f, position.z));
    }
}
