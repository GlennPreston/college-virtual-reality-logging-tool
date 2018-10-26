using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

// Calculate Head Left vs Right turning results
public class LeftVsRight : MonoBehaviour {

    // Gui text fields
    public Text LeftValue;
    public Text RightValue;

    private string path;
    private StreamReader fileReader;
    private string[] line1Values;
    private string[] line2Values;

    private int leftTotal;
    private int rightTotal;
    private int total;

    // Called when the script is enabled
    void Start () {
        path = RetrieveSessionFolders.sessionFolder + "/HeadMovement.csv";
        leftTotal = 0;
        rightTotal = 0;

        try
        {
            fileReader = new StreamReader(path);
            // Read headings from data log file
            line1Values = fileReader.ReadLine().Split(',');
            // Read next line from data log file
            line2Values = fileReader.ReadLine().Split(',');

            // Loops while there are still more lines to be read from the file
            while (line2Values != null)
            {
                // Get value for the first line to compare
                line1Values = line2Values;
                // Read line from file for second line to compare
                line2Values = fileReader.ReadLine().Split(',');

                // Check if next line is null
                if (line2Values != null)
                {
                    // Calculate Head Left vs Right Turning Totals
                    switch (line2Values[1])
                    {
                        case "Straight":
                            if(line1Values[1] == "Slightly Right")
                            {
                                leftTotal += 1;
                            }
                            else if(line1Values[1] == "Slightly Left")
                            {
                                rightTotal += 1;
                            }
                            break;
                        case "Slightly Right":
                            if (line1Values[1] == "Right")
                            {
                                leftTotal += 1;
                            }
                            else if (line1Values[1] == "Straight")
                            {
                                rightTotal += 1;
                            }
                            break;
                        case "Right":
                            if (line1Values[1] == "Greatly Right")
                            {
                                leftTotal += 1;
                            }
                            else if (line1Values[1] == "Slightly Right")
                            {
                                rightTotal += 1;
                            }
                            break;
                        case "Greatly Right":
                            if (line1Values[1] == "Behind")
                            {
                                leftTotal += 1;
                            }
                            else if (line1Values[1] == "Right")
                            {
                                rightTotal += 1;
                            }
                            break;
                        case "Behind":
                            if (line1Values[1] == "Greatly Left")
                            {
                                leftTotal += 1;
                            }
                            else if (line1Values[1] == "Greatly Right")
                            {
                                rightTotal += 1;
                            }
                            break;
                        case "Greatly Left":
                            if (line1Values[1] == "Left")
                            {
                                leftTotal += 1;
                            }
                            else if (line1Values[1] == "Behind")
                            {
                                rightTotal += 1;
                            }
                            break;
                        case "Left":
                            if (line1Values[1] == "Slightly Left")
                            {
                                leftTotal += 1;
                            }
                            else if (line1Values[1] == "Greatly Left")
                            {
                                rightTotal += 1;
                            }
                            break;
                        case "Slightly Left":
                            if (line1Values[1] == "Straight")
                            {
                                leftTotal += 1;
                            }
                            else if (line1Values[1] == "Left")
                            {
                                rightTotal += 1;
                            }
                            break;
                    }
                }
            }
        }
        catch { }

        // Calculate total
        total = leftTotal + rightTotal;

        // Calculate and display Left vs Right turning percentages
        LeftValue.text = (((float)leftTotal / total) * 100f).ToString("n2") + "%";
        RightValue.text = (((float)rightTotal / total) * 100f).ToString("n2") + "%";
    }
}
