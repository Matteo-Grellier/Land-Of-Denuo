using UnityEngine;

public class Fishing : MonoBehaviour
{
    public static void IsFishingSucessfull(int time_remaining)
    {
        //Si le temps est supérieur à la fourchette de temps pour pêcher = pêche échouée.
        if (time_remaining+5 <= Player.elapsedTime)
        {
            //Pêche echouée, le poisson c'est enfuie
            Player.state = Player.State.isNotFishing;
            Player.elapsedTime = 0;
        }
        else
        {
            //Si le poisson mord
            if (Player.elapsedTime >= time_remaining && Player.elapsedTime <= time_remaining + 5)
            {
                //Ici il y aura le message/l'animation du "poisson a mordu !"
            }

            if (Input.GetKeyDown(KeyCode.P) && Player.elapsedTime >= time_remaining && Player.elapsedTime <= time_remaining + 2)
            {
                //Si la pêche a réussi.
                Player.elapsedTime = 0;
                Player.state = Player.State.isNotFishing;
            }
            else if(Player.elapsedTime > 0.1 && Player.elapsedTime < time_remaining && Input.GetKeyDown(KeyCode.P))
            {
                // Si la Pêche a échouée car APPUIE trop tôt.
                Player.state = Player.State.isNotFishing;
                Player.elapsedTime = 0;
            }
        }
        
    }
}
