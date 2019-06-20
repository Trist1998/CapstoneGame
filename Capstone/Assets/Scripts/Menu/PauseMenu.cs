using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        //When escape is pressed the game will become paused or unpaused
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    //Sets time to normal speed and continues the game
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        Screen.lockCursor = true;
    }

    //Freezes time and displays the pause menu
    void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        Screen.lockCursor = false;
    }

    //Loads the main menu 
    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    //Closes application. Doesn't do anything in unity editor but when game is built it'll exit the game
    public void quit()
    {
        Debug.Log("Quit was clicked");
        Application.Quit();
    }
}
