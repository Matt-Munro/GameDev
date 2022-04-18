using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monolith : MonoBehaviour {

	private int scale_y;
	private int scale_z;

	public bool playerPresent;


	void Start () {
		playerPresent = false; //set by itemCollection trigger 

		scale_y = 1;
		scale_z = 1;
	}
	

	//If player is present, 'activates' the monolith and increases its size
	void Update () {


		Vector3 temp = transform.localScale;

		if(playerPresent)
		{
			if(transform.localScale.y < 9)
				temp.y += 2.3f * Time.deltaTime;
			
			if(transform.localScale.z < 4)
				temp.z += 2f * Time.deltaTime;
			
			transform.localScale = temp;


		}
	}
}
