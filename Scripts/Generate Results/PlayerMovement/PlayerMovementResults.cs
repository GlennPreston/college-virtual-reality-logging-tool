using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

// Calculate Player Movement results
public class PlayerMovementResults : MonoBehaviour {

    // Gui text fields
    public Text ForwardText;
    public Text ForwardRightText;
    public Text RightText;
    public Text BackwardRightText;
    public Text BackwardText;
    public Text BackwardLeftText;
    public Text LeftText;
    public Text ForwardLeftText;

    private string path;
    private StreamReader fileReader;
    private string[] line1Values;
    private System.DateTime startTime;
    private System.DateTime endTime;
    private int timeDifference;

    private int[] PlayerMovementValues;

    // Called when script is enabled
    void Start()
    {
        path = RetrieveSessionFolders.sessionFolder + "/PlayerMovement.csv";
        PlayerMovementValues = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        try
        {
            fileReader = new StreamReader(path);
            // Read headings from data log file
            line1Values = fileReader.ReadLine().Split(',');

            // Loops while there are still more lines to be read from the file
            while (line1Values != null)
            {
                // Read next line from data log file
                line1Values = fileReader.ReadLine().Split(',');

                // Check if next line is null
                if (line1Values != null)
                {
                    // Gets start time and end time of the action and calculates the time difference
                    startTime = System.DateTime.ParseExact(line1Values[0], "HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    endTime = System.DateTime.ParseExact(line1Values[4], "HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    timeDifference = (endTime - startTime).Milliseconds;

                    // Calculate Player Movement Direction
                    switch (line1Values[1])
                    {
                        case "Forward ":
                            PlayerMovementValues[0] += timeDifference;
                            break;
                        case "Forward Right":
                            PlayerMovementValues[1] += timeDifference;
                            break;
                        case " Right":
                            PlayerMovementValues[2] += timeDifference;
                            break;
                        case "Backward Right":
                            PlayerMovementValues[3] += timeDifference;
                            break;
                        case "Backward ":
                            PlayerMovementValues[4] += timeDifference;
                            break;
                        case "Backward Left":
                            PlayerMovementValues[5] += timeDifference;
                            break;
                        case " Left":
                            PlayerMovementValues[6] += timeDifference;
                            break;
                        case "Forward Left":
                            PlayerMovementValues[7] += timeDifference;
                            break;
                    }
                }
            }
        }
        catch { }

        // Calculate total
        float PlayerMovementTotal = PlayerMovementValues[0] + PlayerMovementValues[1] + PlayerMovementValues[2] + PlayerMovementValues[3] + PlayerMovementValues[4] + PlayerMovementValues[5] + PlayerMovementValues[6] + PlayerMovementValues[7];

        // Calculate and display Player Movement percentages
        ForwardText.text = (((float)PlayerMovementValues[0] / PlayerMovementTotal) * 100f).ToString("n2") + "%";
        ForwardRightText.text = (((float)PlayerMovementValues[1] / PlayerMovementTotal) * 100f).ToString("n2") + "%";
        RightText.text = (((float)PlayerMovementValues[2] / PlayerMovementTotal) * 100f).ToString("n2") + "%";
        BackwardRightText.text = (((float)PlayerMovementValues[3] / PlayerMovementTotal) * 100f).ToString("n2") + "%";
        BackwardText.text = (((float)PlayerMovementValues[4] / PlayerMovementTotal) * 100f).ToString("n2") + "%";
        BackwardLeftText.text = (((float)PlayerMovementValues[5] / PlayerMovementTotal) * 100f).ToString("n2") + "%";
        LeftText.text = (((float)PlayerMovementValues[6] / PlayerMovementTotal) * 100f).ToString("n2") + "%";
        ForwardLeftText.text = (((float)PlayerMovementValues[7] / PlayerMovementTotal) * 100f).ToString("n2") + "%";
    }
}
