using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

// Extracts session description from file and displays the information
public class SessionDescriptionResults : MonoBehaviour {

    // Gui text fields
    public Text participant;
    public Text date;
    public Text session;

    private string path;
    private StreamReader fileReader;
    private string headings;
    private string line;
    private string[] values;

    // Called when script is enabled
    void Start () {
        path = RetrieveSessionFolders.sessionFolder + "/SessionDescription.csv";

        try
        {
            fileReader = new StreamReader(path);
            // Read headings from file
            line = fileReader.ReadLine();
            // Read next line from file
            line = fileReader.ReadLine();

            // Loops while there are still more lines to be read from the file
            while (line != null)
            {
                // Sets gui text fields
                values = line.Split(',');
                participant.text = values[1];
                date.text = values[2].Replace('_', '/'); ;
                session.text = "Session: " + values[3];
                line = fileReader.ReadLine();
            }
        }
        catch { }
    }
}
