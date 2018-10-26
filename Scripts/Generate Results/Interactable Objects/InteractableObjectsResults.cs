using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

// Calculate interactable objects results
public class InteractableObjectsResults : MonoBehaviour {

    // Gui text fields
    public Text mostLookedAtObject;
    public Text mostLookedAtValue;
    public Text mostClickedObject;
    public Text mostClickedValue;
    public Text mostDoubleClickedObject;
    public Text mostDoubleClickedValue;

    private string path;
    private StreamReader fileReader1;
    private StreamReader fileReader2;
    private string[] line1Values;
    private List<string> l;
    private string[] objectNames;
    private int[] objectLookedAtTotals;
    private int[] objectClickedTotals;
    private int[] objectDoubleClickedTotals;
    private int position;

    private string lookedAtMaxObject;
    private int lookedAtMaxValue;
    private string clickedMaxObject;
    private int clickedMaxValue;
    private string doubleClickedMaxObject;
    private int doubleClickedMaxValue;

    // Called when the script is enabled
    void Start()
    {
        path = RetrieveSessionFolders.sessionFolder + "/Interactables.csv";
        l = new List<string>();
        position = 0;
        lookedAtMaxValue = 0;
        clickedMaxValue = 0;
        doubleClickedMaxValue = 0;

        // Loop through data log once and add all object names to a list
        try
        {
            fileReader1 = new StreamReader(path);
            // Read headings from data log file
            line1Values = fileReader1.ReadLine().Split(',');

            // Loops while there are still more lines to be read from the file
            while (line1Values != null)
            {
                // Read next line from data log file
                line1Values = fileReader1.ReadLine().Split(',');

                // Checks if object is not in the list
                if (!l.Contains(line1Values[0]))
                {
                    l.Add(line1Values[0]);
                }
            }
        }
        catch { }

        // Loop through data log again and track actions for each object from the list in seperate arrays
        try
        {
            // Covert list of objects to array
            objectNames = l.ToArray();
            // Set length of other arrays
            objectLookedAtTotals = new int[objectNames.Length];
            objectClickedTotals = new int[objectNames.Length];
            objectDoubleClickedTotals = new int[objectNames.Length];

            fileReader2 = new StreamReader(path);
            // Read headings from data log file
            line1Values = fileReader2.ReadLine().Split(',');

            // Loops while there are still more lines to be read from the file
            while (line1Values != null)
            {
                // Read next line from data log file
                line1Values = fileReader2.ReadLine().Split(',');

                if (line1Values[1] == "Looked at")
                {
                    // Find postion of object in objectNames array and increment value at same index in objectLookedAtTotals array
                    position = Array.FindIndex(objectNames, m => m == line1Values[0]);
                    objectLookedAtTotals[position] += 1;
                }
                else if (line1Values[1] == "Clicked")
                {
                    // Find postion of object in objectNames array and increment value at same index in objectClickedTotals array
                    position = Array.FindIndex(objectNames, m => m == line1Values[0]);
                    objectClickedTotals[position] += 1;
                }
                else if (line1Values[1] == "Double clicked")
                {
                    // Find postion of object in objectNames array and increment value at same index in objectDoubleClickedTotals array
                    position = Array.FindIndex(objectNames, m => m == line1Values[0]);
                    objectDoubleClickedTotals[position] += 1;
                }
            }
        }
        catch { }

        // Loop through objectNames array
        for (int i = 0; i < objectNames.Length; i++)
        {
            // If looked at value at index i is greater than current looked at max value
            if(objectLookedAtTotals[i] > lookedAtMaxValue)
            {
                // Set index value to max value
                lookedAtMaxValue = objectLookedAtTotals[i];
                // Set index object name to max object name
                lookedAtMaxObject = objectNames[i];
            }

            // If looked at value at index i is greater than current looked at max value
            if (objectClickedTotals[i] > clickedMaxValue)
            {
                // Set index value to max value
                clickedMaxValue = objectClickedTotals[i];
                // Set index object name to max object name
                clickedMaxObject = objectNames[i];
            }

            // If looked at value at index i is greater than current looked at max value
            if (objectDoubleClickedTotals[i] > doubleClickedMaxValue)
            {
                // Set index value to max value
                doubleClickedMaxValue = objectDoubleClickedTotals[i];
                // Set index object name to max object name
                doubleClickedMaxObject = objectNames[i];
            }
        }

        // If looked at max object is not null
        if(lookedAtMaxObject != null)
        {
            // Set gui text fields
            mostLookedAtObject.text = lookedAtMaxObject;
            mostLookedAtValue.text = lookedAtMaxValue.ToString();
        }

        // If clicked max object is not null
        if (clickedMaxObject != null)
        {
            // Set gui text fields
            mostClickedObject.text = clickedMaxObject;
            mostClickedValue.text = clickedMaxValue.ToString();
        }

        // If double clicked max object is not null
        if (doubleClickedMaxObject != null)
        {
            // Set gui text fields
            mostDoubleClickedObject.text = doubleClickedMaxObject;
            mostDoubleClickedValue.text = doubleClickedMaxValue.ToString();
        }
    }
}
