using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour , Observer {

	private bool visible = false;
	private Vector3 position;

	public void observerUpdate(int num)
	{
		if(num == 3)
			visible = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(visible)
		{
			if(position.x == 10)
			{
				position = this.GetComponent<Transform>().localPosition;
				position.x = 30;
				this.GetComponent<Transform>().localPosition = position;
			}
			else
			{
				position = this.GetComponent<Transform>().localPosition;
				position.x -= 10;
				this.GetComponent<Transform>().localPosition = position;
			}
		}
		visible = false;
	}
}
