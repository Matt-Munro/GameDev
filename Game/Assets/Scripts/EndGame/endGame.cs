using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour {

		public Text credits1;
		public Text credits2;

		public AudioSource outroAudio;

		void Start () {

			

			credits1.enabled = false;
			credits2.enabled = false;

			StartCoroutine(credits());
		}	

		//Waits and then displays texts one at a time 
		//Loads menu when finished 
		IEnumerator credits()
		{
				yield return new WaitForSeconds(1);
				outroAudio.Play();

				yield return new WaitForSeconds(2);
				credits1.enabled = true;

				yield return new WaitForSeconds(3);
				credits1.enabled = false;

				yield return new WaitForSeconds(3);
				credits2.enabled = true;

				yield return new WaitForSeconds(3);
				credits2.enabled = false;

				yield return new WaitForSeconds(1.5f);

				SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

		}

}
