using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColour : MonoBehaviour {

    public Button thisBtn;
    public Button otherBtn1;
    public Button otherBtn2;

    private ColorBlock thisBtnColours;
    private ColorBlock otherBtnColours;

    // Called when script instance is being loaded
    private void Awake()
    {
        thisBtnColours = thisBtn.colors;
        otherBtnColours = thisBtn.colors;
    }

    // Called when button is clicked
    public void ChangeColours()
    {
        // Check if button color is not white
        if(thisBtn.colors.normalColor != Color.white)
        {
            // Set this button colour to white
            thisBtnColours.normalColor = Color.white;
            // Set other buttons to grey
            otherBtnColours.normalColor = new Color(0.8f,0.8f,0.8f,0.8f);

            // Apply colours to buttons
            thisBtn.colors = thisBtnColours;
            otherBtn1.colors = otherBtnColours;
            otherBtn2.colors = otherBtnColours;
        }
    }
}
