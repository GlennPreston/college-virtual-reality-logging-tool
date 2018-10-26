using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

// Used to set cube interactivity
// Code used from VR Sample Assets provided by Unity and altered slightly to suit the needs for this projoct
namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class Cube_Interactable : MonoBehaviour
    {
        [SerializeField] private VRInteractiveItem m_InteractiveItem;

        private void OnEnable()
        {
            m_InteractiveItem.OnClick += HandleClick;
        }

        private void OnDisable()
        {
            m_InteractiveItem.OnClick -= HandleClick;
        }

        //Handle the Click event
        private void HandleClick()
        {
            // Reload scene when cube is clicked
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}