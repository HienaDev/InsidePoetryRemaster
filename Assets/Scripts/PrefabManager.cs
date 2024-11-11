using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{

    [SerializeField] private PlayerMovement player;
    public PlayerMovement Player { get { return player; } }


    /// <summary>
    /// We update the player positions through the prefab manager because
    /// it's every teleport ball's parent, and this way we dont need to 
    /// find the player in the scene since the prefabmanager can hold a 
    /// reference to the player
    /// </summary>
    /// <param name="position">Position to update the player to</param>
    public void UpdatePlayerPosition(Vector3 position)
    {
        if (!player.gameObject.activeSelf)
        {
            player.gameObject.SetActive(true);
        }

        player.UpdatePosition(new Vector3(position.x, position.y + 20f, position.z));
    }

    public void DeactivatePlayer()
    {

        player.gameObject.SetActive(false);

    }


}
