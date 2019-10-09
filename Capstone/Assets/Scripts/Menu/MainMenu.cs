using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //This starts the game when the play button is pressed
    public void playGameSingle()
    {
        SceneManager.LoadScene("Scenes/FinalSingle");
    }
    
    public void playGameMultiplayer()
    {
        SceneManager.LoadScene("Scenes/FinalMultiplayer");
    }

    //Closes application. Doesn't do anything in unity editor but when game is built it'll exit the game
    public void QuitGame()
    {
        Debug.Log("Quit was clicked");
        Application.Quit();
    }
}
