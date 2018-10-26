using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerMainMenu : MonoBehaviour
{
    // Called when new session button is clicked
    public void TestEnvironment(string testEnvironmentMenu)
    {
        // Load test environments scene
        SceneManager.LoadScene(testEnvironmentMenu);
    }

    // Called when previous sessions button is clicked
    public void PreviousSessions(string previousSessionsScene)
    {
        // Load previous sessions scene
        SceneManager.LoadScene(previousSessionsScene);
    }

    // Called when exit button is clicked
    public void Exit()
    {
        // Exit the application
        Application.Quit();
    }
}
