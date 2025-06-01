using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperTrigger : MonoBehaviour
{
	// list of game objects to activate
	public GameObject[] TriggerObjs = { null, null, null, null, null };
	public string triggerText;			// text if it should be displayed
	public float triggerTextDuration;	// duration to display text

	HUDmanager HUDref;
	AudioSource MyAudioSource;

	// Start is called before the first frame update
	void Start()
	{
		// find and set reference to HUD game object
		HUDref = FindObjectOfType<HUDmanager>();
		if(HUDref == null)
		{
			Debug.Log("**** MISSING HUD object ****");
		}

		//Fetch the AudioSource from the GameObject
		MyAudioSource = GetComponent<AudioSource>();
	}

	private void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			// activate all game objects in list
			foreach (GameObject GObj in TriggerObjs)
			{
				if (GObj != null)
				{
					if(GObj.activeSelf == true)
					{
						GObj.SetActive(false);
					}
					else
					{
						GObj.SetActive(true);
					}
				}
			}

			// if audio clip is designated, play it
			if (MyAudioSource != null)
			{
				MyAudioSource.Play();
			}

			// if text and duration display using HUD
			if ((triggerText != "") && (triggerTextDuration != 0.0f))
			{
				// display triggerText in HUD
				HUDref.SetText(triggerText, triggerTextDuration);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			// deactivate all game objects in list
			foreach (GameObject GObj in TriggerObjs)
			{
				if (GObj != null)
				{
					if (GObj.activeSelf == true)
					{
						GObj.SetActive(false);
					}
					else
					{
						GObj.SetActive(true);
					}
				}
			}

			// stop designated audio clip
			if (MyAudioSource != null)
			{
				MyAudioSource.Stop();
			}

			// clear trigger text because we left encounter
			HUDref.SetText("", 0.0f);
		}
	}
}
