using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    //Ces m�thodes ne font pas r�ellement ce qu'elles doivent faire, il faut mettre en place le syst�me de sauvegarde

    public void NewGame()
    {
        //Il faudra r�cup�rer l'index de la sc�ne dans laquelle le joueur a arr�t� de jouer.
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit the game...");
        Application.Quit();
    }
}
