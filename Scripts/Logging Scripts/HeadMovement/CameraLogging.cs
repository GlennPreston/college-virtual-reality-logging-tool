using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Track Head Movement
public class CameraLogging : MonoBehaviour {

    private string HeadLeftRight;
    private string HeadUpDown;
    private string HeadTilt;
    private string oldLog;
    private string newLog;
    private string path;

    // Called when script instance is being loaded
    private void Awake()
    {
        // If Head Movement was not selected in the new session menu, disable this script
        if(ButtonManagerTestEnvironmentMenu.headTracking == false)
        {
            this.enabled = false;
        }
    }

    // Called when script is enabled
    void Start ()
    {
        HeadLeftRight = "Staright";
        HeadUpDown = "Straight";
        HeadTilt = "Straight";
        oldLog = "Straight,Straight,Straight";
        newLog = "Straight,Straight,Straight";

        path = ButtonManagerTestEnvironmentMenu.finalPath + "/HeadMovement.csv";
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(System.DateTime.Now.ToString("HH:mm:ss.fff") + "," + newLog + ",");
        writer.Close();
    }
	
    // Called once per frame
	void Update () {

        // Get Head Left-Right rotation
        if(gameObject.transform.rotation.eulerAngles.y <= 20 || gameObject.transform.rotation.eulerAngles.y >= 340)
        {
            HeadLeftRight = "Straight";
        }
        else if (gameObject.transform.rotation.eulerAngles.y <= 339 && gameObject.transform.rotation.eulerAngles.y >= 201)
        {
            if (gameObject.transform.rotation.eulerAngles.y <= 339 && gameObject.transform.rotation.eulerAngles.y >= 291)
            {
                HeadLeftRight = "Slightly Left";
            }
            else if (gameObject.transform.rotation.eulerAngles.y <= 290 && gameObject.transform.rotation.eulerAngles.y >= 250)
            {
                HeadLeftRight = "Left";
            }
            else if (gameObject.transform.rotation.eulerAngles.y <= 249 && gameObject.transform.rotation.eulerAngles.y >= 201)
            {
                HeadLeftRight = "Greatly Left";
            }
        }
        else if (gameObject.transform.rotation.eulerAngles.y <= 159 && gameObject.transform.rotation.eulerAngles.y >= 21)
        {
            if (gameObject.transform.rotation.eulerAngles.y <= 69 && gameObject.transform.rotation.eulerAngles.y >= 21)
            {
                HeadLeftRight = "Slightly Right";
            }
            else if (gameObject.transform.rotation.eulerAngles.y <= 110 && gameObject.transform.rotation.eulerAngles.y >= 70)
            {
                HeadLeftRight = "Right";
            }
            else if (gameObject.transform.rotation.eulerAngles.y <= 159 && gameObject.transform.rotation.eulerAngles.y >= 111)
            {
                HeadLeftRight = "Greatly Right";
            }
        }
        else if (gameObject.transform.rotation.eulerAngles.y <= 200 && gameObject.transform.rotation.eulerAngles.y >= 160)
        {
            HeadLeftRight = "Behind";
        }

        // Get Head Up-Down rotation
        if (gameObject.transform.rotation.eulerAngles.x <= 20 || gameObject.transform.rotation.eulerAngles.x >= 340)
        {
            HeadUpDown = "Straight";
        }
        else if (gameObject.transform.rotation.eulerAngles.x <= 339 && gameObject.transform.rotation.eulerAngles.x >= 201)
        {
            if (gameObject.transform.rotation.eulerAngles.x <= 339 && gameObject.transform.rotation.eulerAngles.x >= 291)
            {
                HeadUpDown = "Slightly Up";
            }
            else if (gameObject.transform.rotation.eulerAngles.x <= 290 && gameObject.transform.rotation.eulerAngles.x >= 250)
            {
                HeadUpDown = "Up";
            }
            else if (gameObject.transform.rotation.eulerAngles.x <= 249 && gameObject.transform.rotation.eulerAngles.x >= 201)
            {
                HeadUpDown = "Greatly Up";
            }
        }
        else if (gameObject.transform.rotation.eulerAngles.x <= 159 && gameObject.transform.rotation.eulerAngles.x >= 21)
        {
            if (gameObject.transform.rotation.eulerAngles.x <= 69 && gameObject.transform.rotation.eulerAngles.x >= 21)
            {
                HeadUpDown = "Slightly Down";
            }
            else if (gameObject.transform.rotation.eulerAngles.x <= 110 && gameObject.transform.rotation.eulerAngles.x >= 70)
            {
                HeadUpDown = "Down";
            }
            else if (gameObject.transform.rotation.eulerAngles.x <= 159 && gameObject.transform.rotation.eulerAngles.x >= 111)
            {
                HeadUpDown = "Greatly Down";
            }
        }
        else if (gameObject.transform.rotation.eulerAngles.x <= 200 && gameObject.transform.rotation.eulerAngles.x >= 160)
        {
            HeadUpDown = "Behind";
        }

        // Get Head Tilt rotation
        if (gameObject.transform.rotation.eulerAngles.z <= 20 || gameObject.transform.rotation.eulerAngles.z >= 340)
        {
            HeadTilt = "Straight";
        }
        else if (gameObject.transform.rotation.eulerAngles.z <= 339 && gameObject.transform.rotation.eulerAngles.z >= 201)
        {
            if (gameObject.transform.rotation.eulerAngles.z <= 339 && gameObject.transform.rotation.eulerAngles.z >= 291)
            {
                HeadTilt = "Slightly Right";
            }
            else if (gameObject.transform.rotation.eulerAngles.z <= 290 && gameObject.transform.rotation.eulerAngles.z >= 250)
            {
                HeadTilt = "Right";
            }
            else if (gameObject.transform.rotation.eulerAngles.z <= 249 && gameObject.transform.rotation.eulerAngles.z >= 201)
            {
                HeadTilt = "Greatly Right";
            }
        }
        else if (gameObject.transform.rotation.eulerAngles.z <= 159 && gameObject.transform.rotation.eulerAngles.z >= 21)
        {
            if (gameObject.transform.rotation.eulerAngles.z <= 69 && gameObject.transform.rotation.eulerAngles.z >= 21)
            {
                HeadTilt = "Slightly Left";
            }
            else if (gameObject.transform.rotation.eulerAngles.z <= 110 && gameObject.transform.rotation.eulerAngles.z >= 70)
            {
                HeadTilt = "Left";
            }
            else if (gameObject.transform.rotation.eulerAngles.z <= 159 && gameObject.transform.rotation.eulerAngles.z >= 111)
            {
                HeadTilt = "Greatly Left";
            }
        }
        else if (gameObject.transform.rotation.eulerAngles.z <= 200 && gameObject.transform.rotation.eulerAngles.z >= 160)
        {
            HeadTilt = "Upside Down";
        }

        // Create new log
        newLog = HeadLeftRight + "," + HeadUpDown + "," + HeadTilt;

        // Checks if new log is the same as the old log
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
            // Set new log to empty string
            newLog = "";
        }
        else
        {
            // Set new log to empty string
            newLog = "";
        }
	}
}
