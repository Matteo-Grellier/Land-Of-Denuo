using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Ces méthodes ne font pas réellement ce qu'elles doivent faire, il faut mettre en place le système de sauvegarde

    public void NewGame()
    {
        //Il faudra récupérer l'index de la scène dans laquelle le joueur a arrêté de jouer.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ContinueGame()
    {
        //Il faudra récupérer l'index de la scène dans laquelle le joueur a arrêté de jouer.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //public void Options()
    //{
    //    GetComponent<MenuFader>().Fade();

    //    GameObject.Find("MainMenu").SetActive(false);
    //    GameObject.Find("OptionsMenu").SetActive(true);
    //}

    public void QuitGame()
    {
        Debug.Log("Quit the game...");
        Application.Quit();
    }
}
