//The following file is a modified version of the following:
//https://www.uni-weimar.de/kunst-und-gestaltung/wiki/GMU:Tutorials/Visual_Interaction/How_to_Control_Unity_with_MaxMsp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class OSCReceiver : MonoBehaviour {

    public string RemoteIP = "127.0.0.1";
    public int SendToPort = 5555;
    public int ListenerPort = 2222;
    public Transform controller;

    private bool isVisible_01 = false;
    private bool isVisible_02 = false;
    private bool isVisible_03 = false;

    private int beat = 0;

    private Osc osc;
    private Udp udp;

    private List<Observer> observers = new List<Observer>();
    
    
    void Start() {
        udp = gameObject.GetComponent<Udp>();
        udp.init(RemoteIP, SendToPort, ListenerPort);

        osc = gameObject.GetComponent<Osc>();
        osc.init(udp);
        osc.SetAllMessageHandler(AllMessageHandler);
       
        addObserver(GameObject.Find("01_Invisible").GetComponent<isVisible_01>());
        addObserver(GameObject.Find("02_Invisible").GetComponent<isVisible_02>());
        addObserver(GameObject.Find("03_Invisible").GetComponent<isVisible_03>());
        addObserver(GameObject.Find("04_Invisible").GetComponent<isVisible_04>());
        addObserver(GameObject.Find("Door").GetComponent<doorVisiblity>());
        addObserver(GameObject.Find("Lift_1").GetComponent<liftMovement>());
        addObserver(GameObject.Find("Lift_2").GetComponent<liftMovement2>());
        addObserver(GameObject.Find("Moving Wall").GetComponent<MovingWall>());
        addObserver(GameObject.Find("Stairs_4").GetComponent<stepsVisible>());
        addObserver(GameObject.Find("Stairs_3").GetComponent<stepsVisible_2>());


    }


    public void AllMessageHandler(OscMessage msg) {


        //message parameters
        string address = msg.Address;

        // different actions, based on the address pattern
        switch(address) {

            case "/visible_01":  
                isVisible_01 = true;  
                notifyObservers(1);
                isVisible_01 = false;       
                break;
            
            case "/visible_02":
                isVisible_02 = true;  
                notifyObservers(2);  
                isVisible_02 = false;              
                break;

            case "/visible_03":   
                isVisible_03 = true;   
                notifyObservers(3);  
                isVisible_03 = false;            
                break;
            
        }

    
    }

    public void notifyObservers(int visible)
    {
        for(int i = 0; i < observers.Count; i++)
        {
            observers[i].observerUpdate(visible);
        }
    }

    public void addObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void removeObserver(Observer observer)
    {
        observers.Remove(observer);
    }

}