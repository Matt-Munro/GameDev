using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRailMovement : MonoBehaviour {

	private Vector3 position;
	private Vector3 position2;

	private Vector3 monolithPosition;

	private Quaternion rotation;

	private bool triggered = false;
	public bool onRail = false;
	private bool move = false;

	private float speed = 5;

	
	void Update () {

		if(onRail)
		{
			StartCoroutine(countDown());
			onRail = false;
		}

		if(move)
		{
			moveOnRail();
		}
	}

	//Moves player at end of game sequence
	private void moveOnRail()
	{
		
		position = this.transform.position;
		monolithPosition = GameObject.Find("Monolith_3").GetComponent<Transform>().position;

		GameObject.Find("Player").GetComponent<Player_Movement>().enabled = false;

		position.x = -22.4f;
		position.y = 8.65f;
		position.z -= (float)(speed * Time.deltaTime);
		transform.position = position;

		monolithPosition = position;
		monolithPosition.z -= 30;
		GameObject.Find("Monolith_3").GetComponent<Transform>().position = monolithPosition;

		if(speed < 35)
			speed += Time.deltaTime;
	}

	
	IEnumerator countDown()
	{
		yield return new WaitForSeconds(2);
		move = true;

		//Gradually lowers volume of music 
		yield return new WaitForSeconds(0.5f);
		GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(83);
		yield return new WaitForSeconds(2f);
		GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(80);
		yield return new WaitForSeconds(3.5f);
		GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(77);
		yield return new WaitForSeconds(5f);
		GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(74);



		//turn off all music programmer switches
		yield return new WaitForSeconds(6);
		GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(3);
	}
}
