using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

// UI pause menu in test environment
public class UIManager : MonoBehaviour {

    public GameObject pauseMenu;

    // Called when script is enabled
    void Start()
    {
        Time.timeScale = 1;
        hidePaused();
    }

    // Called once per frame
    void Update()
    {
        // Check if Esc button is pressed
        if (Input.GetButtonDown("Cancel"))
        {
            // Call pause control
            pauseControl();
        }
    }

    // Called by resume button
    public void pauseControl()
    {
        // Check if time is set to 1 - Game is not paused
        if (Time.timeScale == 1)
        {
            // Disable VR settings
            UnityEngine.XR.XRSettings.enabled = false;
            // Set time to 0 - Pause the game
            Time.timeScale = 0;
            // Show pause menu
            showPaused();
        }
        // Check if time is set to 0 - Game is paused
        else if (Time.timeScale == 0)
        {
            // Enable VR settings
            UnityEngine.XR.XRSettings.enabled = true;
            // Set time to 1 - Unpuase the game
            Time.timeScale = 1;
            // Hide pause menu
            hidePaused();
        }
    }

    // Shows pause menu
    public void showPaused()
    {
        pauseMenu.SetActive(true);
    }

    // Hides pause menu
    public void hidePaused()
    {
        pauseMenu.SetActive(false);
    }

    // Called when exit button is clicked
    // Exit the test environment
    public void exitSession()
    {
        string endTime = System.DateTime.Now.ToString("HH:mm:ss.fff");

        // Write end time to session description file
        string sessionDescriptionPath = ButtonManagerTestEnvironmentMenu.finalPath + "/SessionDescription.csv";
        StreamWriter sessionDescriptionWriter = new StreamWriter(sessionDescriptionPath, true);
        sessionDescriptionWriter.WriteLine(endTime);
        sessionDescriptionWriter.Close();

        // If Head Movement was being tracked
        if (ButtonManagerTestEnvironmentMenu.headTracking)
        {
            // Write end time to Head Movement data log file
            string headTrackingPath = ButtonManagerTestEnvironmentMenu.finalPath + "/HeadMovement.csv";
            StreamWriter headTrackingWriter = new StreamWriter(headTrackingPath, true);
            headTrackingWriter.WriteLine(endTime);
            headTrackingWriter.Close();
        }

        // If Player Movement was being tracked
        if (ButtonManagerTestEnvironmentMenu.movementTracking)
        {
            // Write end time to Player Movement data log file
            string movementTrackingPath = ButtonManagerTestEnvironmentMenu.finalPath + "/PlayerMovement.csv";
            StreamWriter movementTrackingWriter = new StreamWriter(movementTrackingPath, true);
            movementTrackingWriter.WriteLine(endTime);
            movementTrackingWriter.Close();
        }

        // Load main manu
        SceneManager.LoadScene("MainMenu");
    }
}
