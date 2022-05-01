using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRight : MonoBehaviour
{
    public GameObject player;
    public Vector3 position;

    void Update ()
    {
        if (player.transform.position.x >= 5.3){
            player.transform.position = position;
        }
    }
}
