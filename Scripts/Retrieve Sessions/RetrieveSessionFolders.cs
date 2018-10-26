using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Retrieve session folders containing session data log files
public class RetrieveSessionFolders : MonoBehaviour {

    public GameObject buttonPrefab;
    public RectTransform content;

    public static string sessionFolder;

    // Called when script instance is being loaded
    private void Awake()
    {
        sessionFolder = "";
    }

    // Called when script is enabled
    void Start ()
    {
        // Loop through selected date folder directory
        foreach (string file in Directory.GetDirectories(RetrieveDateFolders.dateFolder))
        {
            string name = file.Remove(0, file.LastIndexOf('\\') + 1);

            // Create button for each date folder
            GameObject btn = Instantiate(buttonPrefab);
            btn.transform.SetParent(content);
            btn.transform.localScale = new Vector3(1, 1, 1);
            btn.transform.localPosition = new Vector3(btn.transform.localPosition.x, btn.transform.localPosition.y, 0);
            btn.GetComponentInChildren<Text>().text = name;

            // Create button click event
            Button buttonComponent = btn.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => handleClick(file));
        }
    }

    // Handle button click
    void handleClick(string file)
    {
        // When date folder button click load next scene
        sessionFolder = file;
        SceneManager.LoadScene("PreviousSessions_SessionResults");
    }
}
