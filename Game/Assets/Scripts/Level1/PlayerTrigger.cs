using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {

	public bool playerOnBoard;

	void Start () {
		playerOnBoard = false;
	}
	

	private void OnTriggerEnter(Collider other)
	{
			if(other.gameObject.name == "Player")
			{
				playerOnBoard = true;
			}
  }

	private void OnTriggerStay(Collider other)
  {
		if(other.gameObject.name == "Player")
		{
			playerOnBoard = true;
		}
  }

	private void OnTriggerExit(Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			playerOnBoard = false;
		}
	}
}
