using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChange : MonoBehaviour
{
    public Collider2D colliderName;

    public int Scenenumber;


    void OnTriggerEnter2D(Collider2D colliderName) 
    {
        if(colliderName.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(Scenenumber); //1 is the build order it could be 1065 for you if you have that many scenes
        }
    }
}
