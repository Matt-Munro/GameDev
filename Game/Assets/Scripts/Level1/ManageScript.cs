using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class ManageScript : MonoBehaviour {

	private Udp udp;

	private int testInt = 0;

	// Use this for initialization
	void Start () {

		Cursor.visible = false;
		udp = GameObject.Find("OSC Receiver").GetComponent<Udp>();

		
		enableMax();
	}
	

	public void sendIntToMax(int intToSend)
	{
		string stringToSend = intToSend.ToString();
		byte[] data = Encoding.UTF8.GetBytes(stringToSend);
        udp.SendPacket(data, data.Length);
	}

	void OnApplicationQuit()
    {
        silenceMax();
    }

	public void silenceMax()
	{
		sendIntToMax(0);
		sendIntToMax(1);
		sendIntToMax(3);
	}

	public void enableMax()
	{
		sendIntToMax(2);
		sendIntToMax(84);
		sendIntToMax(3);
	}





}


