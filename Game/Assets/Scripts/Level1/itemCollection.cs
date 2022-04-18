using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollection : MonoBehaviour {

	private int itemNumber;

	private bool item1Collected;
	private bool item2Collected;
	private bool item3Collected;


	void Start () {
		itemNumber = 0;
		item1Collected = false;
		item2Collected = false;
	}
	

	void Update () {
		
	}

	//Once player reaches trigger point, checks which trigger they are at then
	//- Unlocks next row to the music programmer
	//- Opens the music programmer to display newly unlocked row
	//- Sets monolith bool to true, which will cause its code to activate
	//- Sends int to max which adds new background music 
	private void OnTriggerEnter(Collider other)
  {
        

		if(other.gameObject.name == "Player")
		{
			
			itemNumber++;

			if(this.gameObject.name == "Item_Platform_Trigger" && !item1Collected)
			{
				GameObject.Find("UIManager").GetComponent<UIManagerScript>().addRow(1);
				GameObject.Find("UIManager").GetComponent<UIManagerScript>().musicProgrammer();

				
				GameObject.Find("Monolith_1").GetComponent<monolith>().playerPresent = true;

				item1Collected = true;

				GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(96);
			}


			if(this.gameObject.name == "Item_Platform_2_Trigger" && !item2Collected)
			{
				GameObject.Find("UIManager").GetComponent<UIManagerScript>().addRow(2);
				GameObject.Find("UIManager").GetComponent<UIManagerScript>().musicProgrammer();
				
				

				GameObject.Find("Monolith_2").GetComponent<monolith>().playerPresent = true;

				item2Collected = true;

				GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(97);
			}

			if(this.gameObject.name == "Item_Platform_3_Trigger" && !item3Collected)
			{
				GameObject.Find("Monolith_3").GetComponent<monolith>().playerPresent = true;

				item3Collected = true;
				GameObject.Find("Player").GetComponent<PlayerRailMovement>().onRail = true;
			}


		}

	}
}
