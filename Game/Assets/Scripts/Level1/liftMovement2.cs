using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftMovement2 : MonoBehaviour , Observer {

	private Vector3 position;
	private Vector3 maxPosition;
	private Vector3 minPosition;

	private bool maxReached;
	private bool minReached;

	private bool visible;

	private float timeToWait;
	private float waitTime;
	private float timeToMove;

	private bool move;

	public void observerUpdate(int num)
	{
		if(num == 2)
			visible = true;
	}

	// Use this for initialization
	void Start () {
		waitTime = 0.4f;

		move = false;

		timeToWait = waitTime;
		timeToMove = 0.6f;

		position = transform.position;
	

		minPosition = (position -= new Vector3(0, 12f, 0));
		maxPosition = transform.position;
		
		maxReached = false;
		minReached = true;
	}
	
	//
	void Update () {


		if(position.y > maxPosition.y)
		{
			maxReached = true;
			minReached = false;
		}

		if(position.y < minPosition.y)
		{
			minReached = true;
			maxReached = false;
		}



		if(visible)
		{
			move = true;
			timeToMove = 0.6f;
		}
		visible = false;

		if(move && timeToMove > 0)
		{
			if(maxReached)
			{
				position.y -= (float)(1 * Time.deltaTime);
				transform.position = position;
			}
			else if(minReached)
			{
				position.y += (float)(1 * Time.deltaTime);
				transform.position = position;
			}

			timeToMove -= Time.deltaTime;
		}
		else
		{
			move = false;

			timeToWait -= Time.deltaTime;

			if(timeToWait <= 0)
			{
				timeToMove = 0.6f;
				timeToWait = waitTime;
			}
				
		}
		
	}

}
