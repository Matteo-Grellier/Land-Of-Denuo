using UnityEngine;

public class Fishing : Player
{

    static bool alreadyDisplayed0 = false;
    static bool alreadyDisplayed1 = false;
    static bool alreadyDisplayed2 = false;
    static bool alreadyDisplayed3 = false;


    static Player player = new Player();

    public static void Is_fishing_sucessfull(int time_remaining)
    {
        display(3);
        if (time_remaining+5 <= elapsedTime)
        {
            Debug.Log("Pêche echouée, le poisson c'est enfuie");
            state = State.isNotFishing;
            resetDisplay();
            
            elapsedTime = 0;
        }
        else
        {
            if (elapsedTime >= time_remaining && elapsedTime <= time_remaining + 5)
            {
                display(0);
            }
            if (Input.GetKeyDown(KeyCode.E) && elapsedTime >= time_remaining && elapsedTime <= time_remaining + 2)
            {
                display(2);
                elapsedTime = 0;
                state = State.isNotFishing;
                resetDisplay();
            }
            else if(elapsedTime > 0.1 && elapsedTime < time_remaining && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pêche échouée, tu as appuyé trop tôt !!");
                state = State.isNotFishing;
                resetDisplay();
                elapsedTime = 0;
            }
        }
        
    }
    public static void display(int id)
    {
        
        switch (id)
        {
            case 0:
                if (alreadyDisplayed0)
                {
                    break;
                }
                Debug.Log("le poisson a mordu");
                alreadyDisplayed0 = true; 
                break; 
            case 2:
                if (alreadyDisplayed2)
                {
                    break;
                }
                Debug.Log("Pêche réussi");
                alreadyDisplayed2 = true; 
                break;
            case 3:
                if (alreadyDisplayed3)
                {
                    break;
                }
                Debug.Log("La pêche à commencé");
                alreadyDisplayed3 = true;
                break;
            default:
                break;
        }
    }
    public static void resetDisplay()
    {
        alreadyDisplayed0 = false;
        alreadyDisplayed1 = false;
        alreadyDisplayed2 = false;
        alreadyDisplayed3 = false;
    }
}
