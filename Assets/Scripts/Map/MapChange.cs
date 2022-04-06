using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChange : MonoBehaviour
{
    public Collider2D colliderName; //let the script in unity have an argument of wich trigger box is triggered

    public int Scenenumber; //let the script in unity have an argument of wich scene should you launch
    public int TPBoxNumber; //let the script in unity have an argument of wich object you should tp to when spawning

    public Animator transition; // let the script in unity select an animation
    public float transitionTime = 1f ;// let the script in unity select a time of animation

    void OnTriggerEnter2D(Collider2D colliderName) //to call on triggerbox to change scene
    {
        if(colliderName.gameObject.CompareTag("Player"))
        {
            Player.lastTakenTpNumber = TPBoxNumber;
            LoadLevel(Scenenumber);
        }
    }

    public void LoadLevel(int SceneToLoad){ //public to call it in other scripts (like just to change scene for x reasons...)

        StartCoroutine(LoadTransitionLevel(SceneToLoad)); 

    }

    IEnumerator LoadTransitionLevel(int SceneToLoad){

        transition.SetTrigger("quit_trigger");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneToLoad); 
    }



}
