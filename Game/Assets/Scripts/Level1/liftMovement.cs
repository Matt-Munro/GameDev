using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftMovement : MonoBehaviour , Observer {

	private Vector3 position;
	private Vector3 maxPosition; //highest position of lift
	private Vector3 minPosition; //lowest position of lift

	private bool maxReached;
	private bool minReached;

	private bool visible; 

	private float timeToWait; //time left 
	private float waitTime; //
	private float timeToMove; //how long to move for when sound is heard

	private bool move;

	public void observerUpdate(int num)
	{
		if(num == 2)
			visible = true;
	}

	void Start () {
		waitTime = 0.4f;

		move = false;

		timeToWait = waitTime;
		timeToMove = 0.6f;

		position = transform.position; //get starting position

		maxPosition = (position += new Vector3(0, 11.6f, 0));
		minPosition = transform.position;
		
		maxReached = false;
		minReached = true;
	}
	
	//Moves lift up and down when sound 2 is heard
	//Lift stays in position if sound is not being played
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
			Debug.Log("Move");
			move = true;
			timeToMove = 0.6f;
		}
		visible = false;

		//move until time reaches 0
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
