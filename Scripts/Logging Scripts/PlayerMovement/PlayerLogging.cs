using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Track Player Movement
public class PlayerLogging : MonoBehaviour {

    Vector3 movement;

    private string movingVertical;
    private string movingHorizontal;
    private string oldLog;
    private string newLog;
    private string path;

    // Called when script instance is being loaded
    private void Awake()
    {
        // If Player Movement was not selected in the new session menu, disable this script
        if (ButtonManagerTestEnvironmentMenu.movementTracking == false)
        {
            this.enabled = false;
        }
    }

    // Called when script is enabled
    void Start ()
    {
        movingVertical = "";
        movingHorizontal = "";
        oldLog = "Stopped,0,0";
        newLog = "Stopped,0,0";

        path = ButtonManagerTestEnvironmentMenu.finalPath + "/PlayerMovement.csv";
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(System.DateTime.Now.ToString("HH:mm:ss.fff") + "," + newLog + ",");
        writer.Close();
    }
	
    // Called multiple times per frame
	void FixedUpdate ()
    {
        // Get input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Call TrackMovement
        TrackMovement(h, v);
    }

    // Track Player Movement
    void TrackMovement(float h, float v)
    {
        // Check if player is moving
        if (h != 0f || v != 0f)
        {
            movement.Set(h, 0f, v);

            // Check if player is moving left or right
            if (h > 0)
            {
                movingHorizontal = "Right";
            }
            else if (h < 0)
            {
                movingHorizontal = "Left";
            }

            // Check if player is moving forward or backward
            if (v > 0)
            {
                movingVertical = "Forward";
            }
            else if (v < 0)
            {
                movingVertical = "Backward";
            }

            // Create new log
            newLog = movingVertical + " " + movingHorizontal + "," + movement.normalized.z.ToString("0.0") + "," + movement.normalized.x.ToString("0.0");

            if (oldLog != newLog)
            {
                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine(System.DateTime.Now.ToString("HH:mm:ss.fff"));
                writer.Write(System.DateTime.Now.ToString("HH:mm:ss.fff") + "," + newLog + ",");
                writer.Close();
                oldLog = newLog;
                newLog = "";
                movingVertical = "";
                movingHorizontal = "";
            }
            else
            {
                newLog = "";
                movingVertical = "";
                movingHorizontal = "";
            }
        }
        else
        {
            // Set new log to stopped
            newLog = "Stopped,0,0";

            // Check if new log is the same as old log
            if (oldLog != newLog)
            {
                StreamWriter writer = new StreamWriter(path, true);
                // Write end time for old log
                writer.WriteLine(System.DateTime.Now.ToString("HH:mm:ss.fff"));
                // Write new log
                writer.Write(System.DateTime.Now.ToString("HH:mm:ss.fff") + "," + newLog + ",");
                writer.Close();
                // Set new log to old log
                oldLog = newLog;
                // Set variables to empty strings
                newLog = "";
                movingVertical = "";
                movingHorizontal = "";
            }
            else
            {
                // Set variables to empty strings
                newLog = "";
                movingVertical = "";
                movingHorizontal = "";
            }
        }
    }
}
