using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ButtonManagerTestEnvironmentMenu : MonoBehaviour
{

    public static string finalPath = "";
    public static bool headTracking;
    public static bool movementTracking;
    public static bool interactables;

    public Button startSessionBtn;
    public Text userNameInput;
    public Toggle headTrackingInput;
    public Toggle movementTrackingInput;
    public Toggle interactablesInput;

    // Called when start session button is clicked
    public void StartSession(string sceneName)
    {
        startSessionBtn.enabled = false;
        string userName = userNameInput.text.ToString();
        headTracking = headTrackingInput.isOn;
        movementTracking = movementTrackingInput.isOn;
        interactables = interactablesInput.isOn;
        string path = Application.dataPath + "/SessionLogs/" + System.DateTime.Now.ToString("yyyy_MM_dd");
        bool loopVariable = true;
        int sessionNum = 1;

        // Participant name set to Anonymous if no name was entered
        if (userNameInput.text.ToString() == "")
        {
            userName = "Anonymous";
        }

        // Check if date directory doesn't exist
        if (!Directory.Exists(path))
        {
            // Create date directory
            Directory.CreateDirectory(path);

            // Loop until next session number is found
            while (loopVariable)
            {
                // Check if session number directory exists
                if (!Directory.Exists(path + "/Session_" + sessionNum.ToString()))
                {
                    // Create new session directory
                    Directory.CreateDirectory(path + "/Session_" + sessionNum.ToString());
                    finalPath = path + "/Session_" + sessionNum.ToString();
                    loopVariable = false;

                    // Create session description file
                    StreamWriter sessionDescriptionWriter = new StreamWriter(finalPath + "/SessionDescription.csv", true);
                    sessionDescriptionWriter.WriteLine("ENVIRONMENT,PARTICIPANT,DATE,SESSION NUMBER,START TIME,END TIME");
                    sessionDescriptionWriter.Write(sceneName + "," + userName + "," + System.DateTime.Now.ToString("yyyy_MM_dd") + "," + sessionNum.ToString() + "," + System.DateTime.Now.ToString("HH:mm:ss.fff") + ",");
                    sessionDescriptionWriter.Close();

                    // Create head movement data log file if selected
                    if (headTracking)
                    {
                        StreamWriter headTrackingWriter = new StreamWriter(finalPath + "/HeadMovement.csv", true);
                        headTrackingWriter.WriteLine("START TIME,LEFT/RIGHT,UP/DOWN,TILT,END TIME");
                        headTrackingWriter.Close();
                    }

                    // Create player movement data log file if selected
                    if (movementTracking)
                    {
                        StreamWriter movementTrackingWriter = new StreamWriter(finalPath + "/PlayerMovement.csv", true);
                        movementTrackingWriter.WriteLine("START TIME,DIRECTION,VERTICAL SPEED,HORIZONTAL SPEED,END TIME");
                        movementTrackingWriter.Close();
                    }

                    // Create interactable objects data log file if selected
                    if (interactables)
                    {
                        StreamWriter interactablesWriter = new StreamWriter(finalPath + "/Interactables.csv", true);
                        interactablesWriter.WriteLine("NAME,ACTION,TIME");
                        interactablesWriter.Close();
                    }

                    // Enable VR settings and load test environment
                    UnityEngine.XR.XRSettings.enabled = true;
                    SceneManager.LoadScene(sceneName);
                }
                else
                {
                    // Increase session number if it already exists
                    sessionNum++;
                }
            }
        }
        else
        {
            // Loop until next session number is found
            while (loopVariable)
            {
                // Check if session number directory exists
                if (!Directory.Exists(path + "/Session_" + sessionNum.ToString()))
                {
                    // Create new session directory
                    Directory.CreateDirectory(path + "/Session_" + sessionNum.ToString());
                    finalPath = path + "/Session_" + sessionNum.ToString();
                    loopVariable = false;

                    // Create session description file
                    StreamWriter sessionDescriptionWriter = new StreamWriter(finalPath + "/SessionDescription.csv", true);
                    sessionDescriptionWriter.WriteLine("ENVIRONMENT,PARTICIPANT,DATE,SESSION NUMBER,START TIME,END TIME");
                    sessionDescriptionWriter.Write(sceneName + "," + userName + "," + System.DateTime.Now.ToString("yyyy_MM_dd") + "," + sessionNum.ToString() + "," + System.DateTime.Now.ToString("HH:mm:ss.fff") + ",");
                    sessionDescriptionWriter.Close();

                    // Create head movement data log file if selected
                    if (headTracking)
                    {
                        StreamWriter headTrackingWriter = new StreamWriter(finalPath + "/HeadTracking.csv", true);
                        headTrackingWriter.WriteLine("START TIME,LEFT/RIGHT,UP/DOWN,TILT,END TIME");
                        headTrackingWriter.Close();
                    }

                    // Create player movement data log file if selected
                    if (movementTracking)
                    {
                        StreamWriter movementTrackingWriter = new StreamWriter(finalPath + "/MovementTracking.csv", true);
                        movementTrackingWriter.WriteLine("START TIME,DIRECTION,VERTICAL SPEED,HORIZONTAL SPEED,END TIME");
                        movementTrackingWriter.Close();
                    }

                    // Create interactable objects data log file if selected
                    if (interactables)
                    {
                        StreamWriter interactablesWriter = new StreamWriter(finalPath + "/Interactables.csv", true);
                        interactablesWriter.WriteLine("NAME,ACTION,TIME");
                        interactablesWriter.Close();
                    }

                    // Enable VR settings and load test environment
                    UnityEngine.XR.XRSettings.enabled = true;
                    SceneManager.LoadScene(sceneName);
                }
                else
                {
                    // Increase session number if it already exists
                    sessionNum++;
                }
            }
        }
    }
}
