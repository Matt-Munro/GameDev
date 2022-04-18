using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isVisible_01 : MonoBehaviour, Observer {

	private float timeSinceLastBeat = 0.0f;
	  
	private bool visible = false;

	private float timeToShow = 0.1f;

	public void observerUpdate(int num)
	{
		if(num == 1)
			visible = true;
	}
	

	//Checks if sound1 has played then displays the gameobject for 'timeToShow' seconds
	//Allows the player to see the location of the objects if they have activated the sound
	void Update () {
		
		//if sound is heard gameobject renderer is turned on 
		if(visible)
		{
			timeSinceLastBeat = 0.0f;
			
			foreach (Renderer r in GetComponentsInChildren<Renderer>())
   				r.enabled = true;

		}
		visible = false;

		timeSinceLastBeat += Time.deltaTime;

		//if sound has not been heard in 'timeToShow' seconds gameobject renderer is turned off
		if(timeSinceLastBeat > timeToShow)
		{
			foreach (Renderer r in GetComponentsInChildren<Renderer>())
   				r.enabled = false;
			
			timeSinceLastBeat -= timeToShow;
		}

	}

}
