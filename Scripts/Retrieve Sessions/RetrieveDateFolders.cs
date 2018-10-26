using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Retrieve date folders containing previous sessions
public class RetrieveDateFolders : MonoBehaviour {

    public GameObject buttonPrefab;
    public RectTransform content;

    public static string dateFolder;

    // Called when script instance is being loaded
    private void Awake()
    {
        dateFolder = "";
    }

    // Called when script is enabled
    void Start ()
    {
        // Loop through SessionLogs directory
        foreach (string file in Directory.GetDirectories(Application.dataPath + "/SessionLogs"))
        {
            string name = file.Remove(0, file.LastIndexOf('\\') + 1);

            // Create button for each date folder
            GameObject btn = Instantiate(buttonPrefab);
            btn.transform.SetParent(content);
            btn.transform.localScale = new Vector3(1, 1, 1);
            btn.transform.localPosition = new Vector3(btn.transform.localPosition.x, btn.transform.localPosition.y, 0);
            btn.GetComponentInChildren<Text>().text = name.Replace('_', '/');

            // Create button click event
            Button buttonComponent = btn.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => handleClick(file));
        }
    }

    // Handle button click
    void handleClick(string file)
    {
        // When date folder button click load next scene
        dateFolder = file;
        SceneManager.LoadScene("PreviousSessions_Sessions");
    }
}
