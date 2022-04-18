using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorVisiblity : MonoBehaviour , Observer {


	private float timeSinceLastBeat = 0.0f; //time since sound has been played
	  
	private bool visible = true;

	private float timeToHide = 0.4f; //length of time to hide door for

	public void observerUpdate(int num)
	{
		if(num == 2)
			visible = true;
	}

	
	//Checks if sound has played then removes the door gameobject for 'timeToHide' seconds
	//Allows player to walk through gap when they activated the sound 
	void Update () {

		//sound is heard
		//door is hidden and collider is turned off
		if(visible)
		{
			timeSinceLastBeat = 0.0f;
			
			foreach (Renderer r in GetComponentsInChildren<Renderer>())
   				r.enabled = false;

			
			foreach (BoxCollider c in GetComponentsInChildren<BoxCollider>())
				c.enabled = false;

		}
		visible = false;

		timeSinceLastBeat += Time.deltaTime;

		//if sound has not been played in 'timeToHide' seconds, door is reactivated
		if(timeSinceLastBeat > timeToHide)
		{
			foreach (Renderer r in GetComponentsInChildren<Renderer>())
   				r.enabled = true;


			foreach (BoxCollider c in GetComponentsInChildren<BoxCollider>())
				c.enabled = true;
			
			timeSinceLastBeat -= timeToHide;
		}

	}
}
