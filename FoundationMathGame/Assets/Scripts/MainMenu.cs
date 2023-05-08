using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Generic main menu, swaps scenes on button presses
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Loads scene 1 which is the beginning of the tutorial
        SceneManager.LoadScene(1);
    }

    public void PlayNoTutorialGame()
    {
        // Loads scene 2 which is after the tutorial, at the start of the horror game
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        // self explanitory, closes the application
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void OnTriggerEnter(Collider collision)
    {
        // On trigger enter, when the player triggers this, it'll go to the next scene in the build index
        // which has been set up to smoothly transition from Tutorial to the end of the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
