using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Disable VR settings on app start up
public class StartUpController : MonoBehaviour {

    // Called when script is enabled
    void Start ()
    {
        // Disbale VR settings
        UnityEngine.XR.XRSettings.enabled = false;
    }
}
