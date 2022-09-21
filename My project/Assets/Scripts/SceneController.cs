using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene()
    {
        // In main menu press "PLAY" and start the game.
        // In play screen press "MAIN MENU" to return to main menu.

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == 2)
        {
            SceneManager.LoadScene(0);
        }

        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void ReplayButton()
    {
        // press "RESTART" button to restart the game.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
