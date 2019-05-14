using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script allows the player to load up the main game scene from the main menu scene 
// (through the use of the start button), as well  as allowing the player to exit the game 
// once they interact with the exit button.
public class menuScript : MonoBehaviour
{

    public void loadMain()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}