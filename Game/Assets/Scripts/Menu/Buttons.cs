using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeTextColor(Text text)
	{
		if(text.color == Color.white)
			text.color = Color.red;
		else
			text.color = Color.white;
	}
}
