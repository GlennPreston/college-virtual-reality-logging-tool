using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    // Code used from VR Sample Assets provided by Unity and altered slightly to suit the needs for this projoct
    // Track Interactable Objects
    public class InteractableLogging : MonoBehaviour
    {

        public string objectName;
        public bool overAction;
        private string overActionName;
        public bool outAction;
        private string outActionName;
        public bool clickAction;
        private string clickActionName;
        public bool doubleClickAction;
        private string doubleClickActionName;

        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        private string path;

        // Called when script instance is being loaded
        private void Awake()
        {
            // If Interactable Objects was not selected in the new session menu, disable this script
            if (ButtonManagerTestEnvironmentMenu.interactables == false)
            {
                this.enabled = false;
            }
        }

        // Called when script is enabled
        private void Start()
        {
            overActionName = "Looked at";
            outActionName = "Looked away from";
            clickActionName = "Clicked";
            doubleClickActionName = "Double clicked";

            path = ButtonManagerTestEnvironmentMenu.finalPath + "/Interactables.csv";
            StreamWriter writer = new StreamWriter(path, true);
            writer.Close();
        }

        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }

        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }

        //Handle the Over event
        private void HandleOver()
        {
            // If overAction is being recorded for this object
            if (overAction)
            {
                Debug.Log("Show over state");
                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine(objectName + "," + overActionName + "," + System.DateTime.Now.ToString("HH:mm:ss.ff tt"));
                writer.Close();
            }
        }

        //Handle the Out event
        private void HandleOut()
        {
            // If outAction is being recorded for this object
            if (outAction)
            {
                Debug.Log("Show out state");
                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine(objectName + "," + outActionName + "," + System.DateTime.Now.ToString("HH:mm:ss.ff tt"));
                writer.Close();
            }
        }

        //Handle the Click event
        private void HandleClick()
        {
            // If clickAction is being recorded for this object
            if (clickAction)
            {
                Debug.Log("Show click");
                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine(objectName + "," + clickActionName + "," + System.DateTime.Now.ToString("HH:mm:ss.ff tt"));
                writer.Close();
            }
        }

        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            // If doubleClickAction is being recorded for this object
            if (doubleClickAction)
            {
                Debug.Log("Show double click");
                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine(objectName + "," + doubleClickActionName + "," + System.DateTime.Now.ToString("HH:mm:ss.ff tt"));
                writer.Close();
            }
        }
    }
}
