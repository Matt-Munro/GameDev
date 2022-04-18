using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeMovement : MonoBehaviour {

	private Vector3 position;

	private Vector3 maxPosition;
	private Vector3 minPosition;

	private bool maxReached;

	void Start () {
		position = transform.position;

		maxPosition = (position += new Vector3(20, 0, 0));
		minPosition = (position -= new Vector3(20, 0, 0));

		maxReached = false;
	}
	
	//Moves the bridge back and forth across gap
	void Update () {

		if(position.x > maxPosition.x)
		{
			maxReached = true;
		}

		if(position.x < minPosition.x)
		{
			maxReached = false;
		}

		if(maxReached)
		{
			position.x -= (float)(2 * Time.deltaTime);
			transform.position = position;
		}
		else
		{
			position.x += (float)(2 * Time.deltaTime);
			transform.position = position;
		}
	}
}
