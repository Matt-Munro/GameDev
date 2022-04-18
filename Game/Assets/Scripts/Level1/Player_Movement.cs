using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour {

	public float speed = 6.0f;
	public float gravity = -9.8f;

	private CharacterController _charCont;

	ManageScript manager;


	void Start () {
		
		_charCont = GetComponent<CharacterController>();

		manager = GameObject.Find("Manager").GetComponent<ManageScript>();
	}
	

	void Update () {

		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);

		movement = Vector3.ClampMagnitude(movement, speed); //limit max speed

		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charCont.Move(movement);

	}

	private void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.name == "Exit")
		{
			Cursor.visible = true;
			GameObject.Find("Manager").GetComponent<ManageScript>().silenceMax();
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(4);
			SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
		}

		if(other.gameObject.name == "Lower1")
		{
			Vector3 returnPosition = new Vector3(44, 0.5f, 47);

			this.GetComponent<Transform>().localPosition = returnPosition;
		}

		if(other.gameObject.name == "Lower2")
		{
			Vector3 returnPosition = new Vector3(102, 1.5f, 84);

			this.GetComponent<Transform>().localPosition = returnPosition;
		}

		if(other.gameObject.name == "Lower3")
		{
			Vector3 returnPosition = new Vector3(45, 0.5f, -12.5f);

			this.GetComponent<Transform>().localPosition = returnPosition;
		}

		if(other.gameObject.name == "Lower4")
		{
			Vector3 returnPosition = new Vector3(60, 12f, -45);

			this.GetComponent<Transform>().localPosition = returnPosition;
		}

		if(other.gameObject.name == "Lower5")
		{
			Vector3 returnPosition = new Vector3(-22, 8.7f, -86);

			this.GetComponent<Transform>().localPosition = returnPosition;
		}

		if(other.gameObject.name == "Lower_Lift_1" || other.gameObject.name == "Lower_Lift_2")
		{
			Vector3 returnPosition = new Vector3(38, 2, -44);

			this.GetComponent<Transform>().localPosition = returnPosition;
		}
    }

}
