using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDmanager : MonoBehaviour
{
	[HideInInspector]
	public GUIStyle HUDstyle;       // set the text style of the frame counter
	[HideInInspector]
	public string HUDtext;          // display text on the HUD
	[HideInInspector]
	public Rect HUDrect;			// area for HUD display

	// Start is called before the first frame update
	void Start()
    {
		
		HUDstyle.alignment = TextAnchor.UpperLeft;		// sets text flow left to right from top
		HUDstyle.fontSize = 40;							// font size to 40 (for HD display
		HUDstyle.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);  // text color white White
		HUDstyle.wordWrap = true;

		// sets HUD display to bottom quarter of screen
		HUDrect = new Rect(0, Screen.height*0.75f, Screen.width, Screen.height*0.25f);
    }

    // Update is called once per frame
    void Update()
    {
		// if the player presses ESCAPE, quit
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	// Display HUD values
	private void OnGUI()
	{
		// if text is not empty, display it
		if (HUDtext != "")
		{
			GUI.Box(HUDrect, "");					// displays default GUI box without header
			GUI.Label(HUDrect, HUDtext, HUDstyle);	// shows text in box with defined style
		}
	}

	// sets text to display, and duration in seconds
	public void SetText(string newText, float displayTime)
	{
		string temp;
		temp = newText.Replace("\\n", "\n");
		temp = temp.Replace("\\t", "\t");
		HUDtext = temp;
		Invoke("ClearText", displayTime);
	}

	// called when duration expires
	void ClearText()
	{
		// turn off HUD text
		HUDtext = "";
	}
}
