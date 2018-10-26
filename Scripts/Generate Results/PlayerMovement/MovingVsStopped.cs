using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

// Calculate Moving vs Stopped results
public class MovingVsStopped : MonoBehaviour {

    // Gui text fields
    public Text StoppedValue;
    public Text MovingValue;

    private string path;
    private StreamReader fileReader;
    private string[] line1Values;

    private int stoppedTotal;
    private int movingTotal;
    private int total;

    // Called when the script is enabled
    void Start()
    {
        path = RetrieveSessionFolders.sessionFolder + "/PlayerMovement.csv";
        stoppedTotal = 0;
        movingTotal = 0;

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

                // Calculate Head Left vs Right Turning Totals
                if (line1Values != null)
                {
                    // Check if moving or stopped
                    if(line1Values[1] == "Stopped")
                    {
                        stoppedTotal += 1;
                    }
                    else
                    {
                        movingTotal += 1;
                    }
                }
            }
        }
        catch { }

        // Calculate total
        total = stoppedTotal + movingTotal;

        // Calculate and display Moving vs Stopped percentages
        StoppedValue.text = (((float)stoppedTotal / total) * 100f).ToString("n2") + "%";
        MovingValue.text = (((float)movingTotal / total) * 100f).ToString("n2") + "%";
    }
}
