using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

// Calculate head movement results
public class HeadMovementResults : MonoBehaviour {

    // Head Left-Right gui text fields
    public Text LRStraightText;
    public Text LRSlightlyRightText;
    public Text LRRightText;
    public Text LRGreatlyRightText;
    public Text LRBehindText;
    public Text LRGreatlyLeftText;
    public Text LRLeftText;
    public Text LRSlightlyLeftText;

    // Head Up-Down gui text fields
    public Text UDStraightText;
    public Text UDSlightlyUpText;
    public Text UDUpText;
    public Text UDGreatlyUpText;
    public Text UDBehindText;
    public Text UDGreatlyDownText;
    public Text UDDownText;
    public Text UDSlightlyDownText;

    // Head Tilt gui text fields
    public Text TStraightText;
    public Text TSlightlyRightText;
    public Text TRightText;
    public Text TGreatlyRightText;
    public Text TUpsideDownText;
    public Text TGreatlyLeftText;
    public Text TLeftText;
    public Text TSlightlyLeftText;

    private string path;
    private StreamReader fileReader;
    private string[] line1Values;
    private System.DateTime startTime;
    private System.DateTime endTime;
    private int timeDifference;

    private int[] LeftRightRotationValues;
    private int[] UpDownRotationValues;
    private int[] TiltRotationValues;

    // Called when the script is enabled
    void Start()
    {
        path = RetrieveSessionFolders.sessionFolder + "/HeadMovement.csv";
        LeftRightRotationValues = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        UpDownRotationValues = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        TiltRotationValues = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

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

                // Checks if next line is null
                if(line1Values != null)
                {
                    // Gets start time and end time of the action and calculates the time difference
                    startTime = System.DateTime.ParseExact(line1Values[0], "HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    endTime = System.DateTime.ParseExact(line1Values[4], "HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    timeDifference = (endTime - startTime).Milliseconds;

                    // Calculate Head Left-Right Rotation Values
                    switch(line1Values[1])
                    {
                        case "Straight":
                            LeftRightRotationValues[0] += timeDifference;
                            break;
                        case "Slightly Right":
                            LeftRightRotationValues[1] += timeDifference;
                            break;
                        case "Right":
                            LeftRightRotationValues[2] += timeDifference;
                            break;
                        case "Greatly Right":
                            LeftRightRotationValues[3] += timeDifference;
                            break;
                        case "Behind":
                            LeftRightRotationValues[4] += timeDifference;
                            break;
                        case "Greatly Left":
                            LeftRightRotationValues[5] += timeDifference;
                            break;
                        case "Left":
                            LeftRightRotationValues[6] += timeDifference;
                            break;
                        case "Slightly Left":
                            LeftRightRotationValues[7] += timeDifference;
                            break;
                    }

                    // Calculate Head Up-Down Rotation Values
                    switch (line1Values[2])
                    {
                        case "Straight":
                            UpDownRotationValues[0] += timeDifference;
                            break;
                        case "Slightly Up":
                            UpDownRotationValues[1] += timeDifference;
                            break;
                        case "Up":
                            UpDownRotationValues[2] += timeDifference;
                            break;
                        case "Greatly Up":
                            UpDownRotationValues[3] += timeDifference;
                            break;
                        case "Behind":
                            UpDownRotationValues[4] += timeDifference;
                            break;
                        case "Greatly Down":
                            UpDownRotationValues[5] += timeDifference;
                            break;
                        case "Down":
                            UpDownRotationValues[6] += timeDifference;
                            break;
                        case "Slightly Down":
                            UpDownRotationValues[7] += timeDifference;
                            break;
                    }

                    // Calculate Head Tilt Rotation Values
                    switch (line1Values[3])
                    {
                        case "Straight":
                            TiltRotationValues[0] += timeDifference;
                            break;
                        case "Slightly Right":
                            TiltRotationValues[1] += timeDifference;
                            break;
                        case "Right":
                            TiltRotationValues[2] += timeDifference;
                            break;
                        case "Greatly Right":
                            TiltRotationValues[3] += timeDifference;
                            break;
                        case "Upside Down":
                            TiltRotationValues[4] += timeDifference;
                            break;
                        case "Greatly Left":
                            TiltRotationValues[5] += timeDifference;
                            break;
                        case "Left":
                            TiltRotationValues[6] += timeDifference;
                            break;
                        case "Slightly Left":
                            TiltRotationValues[7] += timeDifference;
                            break;
                    }
                }
            }
        }
        catch { }

        // Calculate totals
        float LeftRightTotal = LeftRightRotationValues[0] + LeftRightRotationValues[1] + LeftRightRotationValues[2] + LeftRightRotationValues[3] + LeftRightRotationValues[4] + LeftRightRotationValues[5] + LeftRightRotationValues[6] + LeftRightRotationValues[7];
        float UpDownTotal = UpDownRotationValues[0] + UpDownRotationValues[1] + UpDownRotationValues[2] + UpDownRotationValues[3] + UpDownRotationValues[4] + UpDownRotationValues[5] + UpDownRotationValues[6] + UpDownRotationValues[7];
        float TiltTotal = TiltRotationValues[0] + TiltRotationValues[1] + TiltRotationValues[2] + TiltRotationValues[3] + TiltRotationValues[4] + TiltRotationValues[5] + TiltRotationValues[6] + TiltRotationValues[7];

        // Calculate and display Head Left-Right Rotation percentages
        LRStraightText.text = (((float)LeftRightRotationValues[0] / LeftRightTotal) * 100f).ToString("n2") + "%";
        LRSlightlyRightText.text = (((float)LeftRightRotationValues[1] / LeftRightTotal) * 100f).ToString("n2") + "%";
        LRRightText.text = (((float)LeftRightRotationValues[2] / LeftRightTotal) * 100f).ToString("n2") + "%";
        LRGreatlyRightText.text = (((float)LeftRightRotationValues[3] / LeftRightTotal) * 100f).ToString("n2") + "%";
        LRBehindText.text = (((float)LeftRightRotationValues[4] / LeftRightTotal) * 100f).ToString("n2") + "%";
        LRGreatlyLeftText.text = (((float)LeftRightRotationValues[5] / LeftRightTotal) * 100f).ToString("n2") + "%";
        LRLeftText.text = (((float)LeftRightRotationValues[6] / LeftRightTotal) * 100f).ToString("n2") + "%";
        LRSlightlyLeftText.text = (((float)LeftRightRotationValues[7] / LeftRightTotal) * 100f).ToString("n2") + "%";

        // Calculate and display Head Left-Right Rotation percentages
        UDStraightText.text = (((float)UpDownRotationValues[0] / UpDownTotal) * 100f).ToString("n2") + "%";
        UDSlightlyUpText.text= (((float)UpDownRotationValues[1] / UpDownTotal) * 100f).ToString("n2") + "%";
        UDUpText.text = (((float)UpDownRotationValues[2] / UpDownTotal) * 100f).ToString("n2") + "%";
        UDGreatlyUpText.text = (((float)UpDownRotationValues[3] / UpDownTotal) * 100f).ToString("n2") + "%";
        UDBehindText.text = (((float)UpDownRotationValues[4] / UpDownTotal) * 100f).ToString("n2") + "%";
        UDGreatlyDownText.text = (((float)UpDownRotationValues[5] / UpDownTotal) * 100f).ToString("n2") + "%";
        UDDownText.text = (((float)UpDownRotationValues[6] / UpDownTotal) * 100f).ToString("n2") + "%";
        UDSlightlyDownText.text = (((float)UpDownRotationValues[7] / UpDownTotal) * 100f).ToString("n2") + "%";

        // Calculate and display Head Left-Right Rotation percentages
        TStraightText.text = (((float)TiltRotationValues[0] / TiltTotal) * 100f).ToString("n2") + "%";
        TSlightlyRightText.text = (((float)TiltRotationValues[1] / TiltTotal) * 100f).ToString("n2") + "%";
        TRightText.text = (((float)TiltRotationValues[2] / TiltTotal) * 100f).ToString("n2") + "%";
        TGreatlyRightText.text = (((float)TiltRotationValues[3] / TiltTotal) * 100f).ToString("n2") + "%";
        TUpsideDownText.text = (((float)TiltRotationValues[4] / TiltTotal) * 100f).ToString("n2") + "%";
        TGreatlyLeftText.text = (((float)TiltRotationValues[5] / TiltTotal) * 100f).ToString("n2") + "%";
        TLeftText.text = (((float)TiltRotationValues[6] / TiltTotal) * 100f).ToString("n2") + "%";
        TSlightlyLeftText.text = (((float)TiltRotationValues[7] / TiltTotal) * 100f).ToString("n2") + "%";
    }
}
