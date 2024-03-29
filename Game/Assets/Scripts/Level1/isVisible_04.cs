﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isVisible_04 : MonoBehaviour , Observer {

	private float timeSinceLastBeat = 0.0f;
	  
	private bool visible = false;

	private float timeToShow;

	private GameObject child;
	private GameObject childChild;

	private int currentChild = 0;

	//Total number of child objects attach
	private int totalChildren; 

	public void observerUpdate(int num)
	{
		if(num == 1)
			visible = true;
	}

	void Start () {

		totalChildren = this.gameObject.transform.childCount;

		foreach (Renderer r in GetComponentsInChildren<Renderer>())
   				r.enabled = false;
		
	}
	
	//Checks if sound1 has played then displays its child objects and grandchild one at a time
	//Similar to invisible1 but only one of the objects is shown, in sequence, rather than all at once
	void Update () {

		if(visible)
		{
			//
			if(currentChild < totalChildren-1)
			{
				currentChild++;
			}
			else 
			{
				currentChild = 0;
			}
			

			if(currentChild == 0)
			{
				child = this.gameObject.transform.GetChild(currentChild).gameObject;
				Renderer childRenderer = child.GetComponent<Renderer>();
				childRenderer.enabled = true;

				childChild = child.gameObject.transform.GetChild(0).gameObject;
				childRenderer = childChild.GetComponent<Renderer>();
				childRenderer.enabled = true;



				child = this.gameObject.transform.GetChild(totalChildren - 1).gameObject;
				childRenderer = child.GetComponent<Renderer>();
				childRenderer.enabled = false;
				
				childChild = child.gameObject.transform.GetChild(0).gameObject;
				childRenderer = childChild.GetComponent<Renderer>();
				childRenderer.enabled = false;
			}
			else
			{
				child = this.gameObject.transform.GetChild(currentChild).gameObject;
				Renderer childRenderer = child.GetComponent<Renderer>();
				childRenderer.enabled = true;

				childChild = child.gameObject.transform.GetChild(0).gameObject;
				childRenderer = childChild.GetComponent<Renderer>();
				childRenderer.enabled = true;

				child = this.gameObject.transform.GetChild(currentChild - 1).gameObject;
				childRenderer = child.GetComponent<Renderer>();
				childRenderer.enabled = false;

				childChild = child.gameObject.transform.GetChild(0).gameObject;
				childRenderer = childChild.GetComponent<Renderer>();
				childRenderer.enabled = false;
			}

		}
		visible = false;

	}
}
