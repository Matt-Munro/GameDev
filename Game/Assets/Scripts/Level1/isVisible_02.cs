using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isVisible_02 : MonoBehaviour , Observer {

	private float timeSinceLastBeat = 0.0f;
	  
	private bool visible = false;

	private float timeToShow = 0.5f;


	public void observerUpdate(int num)
	{
		if(num == 2)
			visible = true;
	}
	
	//Checks if sound2 has played then displays the gameobject for 'timeToShow' seconds
	//Allows the player to see the location of the objects if they have activated the sound
	void Update () {

		if(visible)
		{
			timeSinceLastBeat = 0.0f;
			
			foreach (Renderer r in GetComponentsInChildren<Renderer>())
   				r.enabled = true;

		}
		visible = false;

		timeSinceLastBeat += Time.deltaTime;

		if(timeSinceLastBeat > timeToShow)
		{
			foreach (Renderer r in GetComponentsInChildren<Renderer>())
   				r.enabled = false;
			
			timeSinceLastBeat -= timeToShow;
		}
	}

}
