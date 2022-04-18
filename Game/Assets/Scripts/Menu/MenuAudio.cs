using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAudio : MonoBehaviour {

	public AudioSource menuAudio;

	public Text gameTitle;

	// Use this for initialization
	void Start () {
		menuAudio.volume = 0.1f;
		menuAudio.loop = true;
		menuAudio.Play();
		InvokeRepeating("changeTitle", 0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void changeTitle()
	{
		if(gameTitle.enabled)
		{	
			gameTitle.enabled = false;
		}
		else
		{
			gameTitle.enabled = true;
		}
	}
}
