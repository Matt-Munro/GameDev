using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {

	public GameObject canvas;
	public GameObject musicCanvas;
	public GameObject userGuide;
	public GameObject musicImage;
	public GameObject buttonPrefab;
	public GameObject[] sequencerButtons;

	private bool[] isButtonOn; //true if music programmer button has been selected 

	private int beatCounter = 0;
	private bool firstTime = true;

	private bool secondRowActive;
	private bool thirdRowActive;

	private int debug_rowNum; //allows row to be added in testing without reaching checkpoints


	//music programmer colors
	private Color color_beat = Color.white;
	private Color color_r1_active = Color.red;
	private Color color_r1_inactive = Color.grey;
	private Color color_r2_active = Color.green;
	private Color color_r2_inactive = Color.grey;
	private Color color_r3_active = Color.blue;
	private Color color_r3_inactive = Color.grey;


	public int volume = 100;


	//Uses button prefab to setup music programmer
	void buttonSetup()
	{
		float x_pos = -560;
		float y_pos = 60;
		float z_pos = 0;

		sequencerButtons = new GameObject[48];

		isButtonOn = new bool[48];
		
		for(int i = 0; i < 48; i++)
		{
			sequencerButtons[i] = Instantiate(buttonPrefab) as GameObject;
			
			sequencerButtons[i].transform.SetParent(musicImage.transform);  

			RectTransform rt = sequencerButtons[i].GetComponent<RectTransform>();
			rt.localPosition = new Vector3(x_pos, y_pos, z_pos);


			int captured = i;
    		sequencerButtons[i].GetComponent<Button>().onClick.AddListener(() => sequencer(captured));
			

			if((i == 15) || (i == 31))
			{
				y_pos -= 70;
				x_pos = -560;
			}
			else
			{
				x_pos += 75f;
			}
			
			isButtonOn[i] = false;
		}
		

		//turns off second and third row
		//unlocked later by player
		for(int i = 16; i < 48; i++)
		{
			sequencerButtons[i].GetComponent<Button>().enabled = false;
			sequencerButtons[i].GetComponentInChildren<Text>().text = "X";
		}
	}

	//called when music programmer button is pressed
	//turns the button on or off and updates colour 
	public void sequencer(int button)
	{
		
		if(isButtonOn[button])
		{
			if(button < 16)
			{
				isButtonOn[button] = false;
				sequencerButtons[button].GetComponent<Image>().color = color_r1_inactive;
			}
			else if(button < 32)
			{
				isButtonOn[button] = false;
				sequencerButtons[button].GetComponent<Image>().color = color_r2_inactive;
			}
			else
			{
				isButtonOn[button] = false;
				sequencerButtons[button].GetComponent<Image>().color = color_r3_inactive;
			}
			
		}
		else
		{
			if(button < 16)
			{
				isButtonOn[button] = true;
				sequencerButtons[button].GetComponent<Image>().color = color_r1_active;
			}
			else if(button < 32)
			{
				isButtonOn[button] = true;
				sequencerButtons[button].GetComponent<Image>().color = color_r2_active;
			}
			else
			{
				isButtonOn[button] = true;
				sequencerButtons[button].GetComponent<Image>().color = color_r3_active;
			}
			
		}

		//update max sequencer 
		GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(button + 10);
	}

	
	//called when player triggers monolith
	//unlocks next row of programmer
	public void addRow(int item)
	{
		if(item == 1)
		{
			for(int i = 16; i < 32; i++)
			{
				sequencerButtons[i].GetComponent<Button>().enabled = true;
				sequencerButtons[i].GetComponentInChildren<Text>().text = "";
			}

			secondRowActive = true;
		}

		if(item == 2)
		{
			for(int i = 32; i < 48; i++)
			{
				sequencerButtons[i].GetComponent<Button>().enabled = true;
				sequencerButtons[i].GetComponentInChildren<Text>().text = "";
			}
			thirdRowActive = true;
		}
	}


	public void Start()
	{
		debug_rowNum = 0;

		Scene currentScene = SceneManager.GetActiveScene ();

		if(currentScene.name == "Level1")
		{
			Cursor.visible = false;
			secondRowActive = false;
			thirdRowActive = false;

			canvas.SetActive(false);
			musicCanvas.SetActive(false);

			buttonSetup();

			//Ensures green line in music programmer is in time with max sequencer 
			InvokeRepeating("bpm", 0f, 0.125f);
		}
		
	}


	public void Update()
	{
		
		//for testing and debugging
		//adds row without having to activate monolith
		if (Input.GetKeyDown("l"))
		{
			debug_rowNum++;
			addRow(debug_rowNum);
		}

		if(userGuide.activeInHierarchy == true)
		{
			Cursor.visible = true;
		}

		if(canvas.activeInHierarchy == true)
		{
			Cursor.visible = true;
		}
		
		
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			pauseMenu();
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			musicProgrammer();
		}
	}

	private void pauseMenu()
	{
		if(canvas.activeInHierarchy == true)
			{
				canvas.SetActive(false);
				Cursor.visible = false;
			}
			else
			{
				canvas.SetActive(true);
				Cursor.visible = true;
			}
	}

	public void musicProgrammer()
	{
		if(musicCanvas.activeInHierarchy == true)
			{
				musicCanvas.SetActive(false);
				Cursor.visible = false;
			}
			else
			{
				musicCanvas.SetActive(true);
				Cursor.visible = true;
			}
	}

	public void hideMouse()
	{
		Cursor.visible = false;
	}

	
	//updates music programmer on every beat
	//moves current beat button and sets colours for active and non-active buttons 
	public void bpm()
	{
		//Starts max sequencer 
		if(firstTime)
		{
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(0);

			firstTime = false;
		}
		

		if(beatCounter == 16)
		{
			beatCounter = 0;
		}

		if(beatCounter == 0)
		{
			//top line-----------------------------------------------------------------------
			sequencerButtons[beatCounter].GetComponent<Image>().color = color_beat;

			if(!isButtonOn[beatCounter + 15])
			{
				sequencerButtons[beatCounter + 15].GetComponent<Image>().color = color_r1_inactive;
			}
			else
			{
				sequencerButtons[beatCounter + 15].GetComponent<Image>().color = color_r1_active;
			}


			//second line-----------------------------------------------------------------------
			if(secondRowActive)
			{
				sequencerButtons[beatCounter + 16].GetComponent<Image>().color = color_beat;
			
				if(!isButtonOn[beatCounter + 31])
				{
					sequencerButtons[beatCounter + 31].GetComponent<Image>().color = color_r2_inactive;
				}
				else
				{
					sequencerButtons[beatCounter + 31].GetComponent<Image>().color = color_r2_active;
				}
			}
			
			

			//third line-----------------------------------------------------------------------
			if(thirdRowActive)
			{
				sequencerButtons[beatCounter + 32].GetComponent<Image>().color = color_beat;

				if(!isButtonOn[beatCounter + 47])
				{
					sequencerButtons[beatCounter + 47].GetComponent<Image>().color = color_r3_inactive;
				}
				else
				{
					sequencerButtons[beatCounter + 47].GetComponent<Image>().color = color_r3_active;
				}
			}
			
			
		}
		else
		{
			//top line-----------------------------------------------------------------------
			sequencerButtons[beatCounter].GetComponent<Image>().color = color_beat;

			if(!isButtonOn[beatCounter-1])
			{
				sequencerButtons[beatCounter - 1].GetComponent<Image>().color = color_r1_inactive;
			}
			else
			{
				sequencerButtons[beatCounter - 1].GetComponent<Image>().color = color_r1_active;
			}



			//second line-----------------------------------------------------------------------
			if(secondRowActive)
			{
				sequencerButtons[beatCounter + 16].GetComponent<Image>().color = color_beat;

				if(!isButtonOn[beatCounter + 15])
				{
					sequencerButtons[beatCounter + 15].GetComponent<Image>().color = color_r2_inactive;
				}
				else
				{
					sequencerButtons[beatCounter + 15].GetComponent<Image>().color = color_r2_active;
				}
			}
			
			

			//third line-----------------------------------------------------------------------
			if(thirdRowActive)
			{
				sequencerButtons[beatCounter + 32].GetComponent<Image>().color = color_beat;

				if(!isButtonOn[beatCounter + 31])
				{
					sequencerButtons[beatCounter  + 31].GetComponent<Image>().color = color_r3_inactive;
				}
				else
				{
					sequencerButtons[beatCounter  + 31].GetComponent<Image>().color = color_r3_active;
				}
			}
			
			
		}

		beatCounter++;

	}

	//Called when user clicks 'clear' button at side of row
	//Turns off all buttons in the row 
	public void turnOffRow(int row)
	{
		int button = 0;

		if(row == 1)
			button = 0;
		else if(row == 2)
			button = 16;
		else if(row == 3)
			button = 32;

		int upperBound = button + 16;

		for( ; button < upperBound; button++)
		{
			if(isButtonOn[button] == true)
			{
				GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(button + 10);
				isButtonOn[button] = false;
				sequencerButtons[button].GetComponent<Image>().color = color_r1_inactive;
			}
		}
	}

	public void resumeGame()
	{
		canvas.SetActive(false);
		Cursor.visible = false;
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Level1");
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	//adjusts mouse sensitivity for Player and Camera 
	public void sensitivitySlider(Slider slider)
	{
		GameObject.Find("Player").GetComponent<Camera_Control>().sensHorizontal = slider.value;
		GameObject.Find("Player").GetComponent<Camera_Control>().sensVertical = slider.value;

		GameObject.Find("Main Camera").GetComponent<Camera_Control>().sensHorizontal = slider.value;
		GameObject.Find("Main Camera").GetComponent<Camera_Control>().sensVertical = slider.value;
	}

	//adjusts volume in max 
	public void sendSliderValue(Slider slider)
	{

		volume = ((int)slider.value);

		if(volume < 10)
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(75);
		else if(volume < 20)
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(76);
		else if(volume < 30)
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(77);
		else if(volume < 40)
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(78);
		else if(volume < 50)
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(79);
		else if(volume < 60)
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(80);
		else if(volume < 70)
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(81);
		else if(volume < 80)
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(82);
		else if(volume < 90)
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(83);
		else if(volume < 100)
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(84);
		else 
			GameObject.Find("Manager").GetComponent<ManageScript>().sendIntToMax(85);
			
	}
}
