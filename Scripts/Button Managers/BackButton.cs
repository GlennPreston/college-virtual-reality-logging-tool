using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

    // Called when back button is clicked
    public void Back(string scene)
    {
        // Load new scene
        SceneManager.LoadScene(scene);
    }
}
