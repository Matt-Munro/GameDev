using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startup : MonoBehaviour {

	public Text warning;  //Flashing images warning 
	public Image warningImage;
	
	void Start () {
		warning.enabled = true;


		string filePath = ("GameAudio.app");
		System.Diagnostics.Process.Start(filePath);

		StartCoroutine(countDown());
	}
	
	
	void Update () {
		
	}

	//Display flashing images warning
	IEnumerator countDown()
	{
		yield return new WaitForSeconds(3);
		warning.enabled = false;
		warningImage.enabled = false;
	}
}
