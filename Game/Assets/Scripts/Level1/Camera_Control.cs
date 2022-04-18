//The following is a modified version of:
//https://www.youtube.com/watch?v=Ov9ekwAGhMA&index=7&list=PLuvBt4R-XLol3y62QO8LIfkthJEHMYXvz&t=0s


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour {

	public GameObject canvas;
	public GameObject musicCanvas;
	public GameObject userGuide;

	public enum RotationAxis{
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxis axes = RotationAxis.MouseX;

	private float minimumVert = -90.0f;
	private float maximumVert = 45.0f;

	public float sensHorizontal = 5.0f;
	public float sensVertical = 5.0f;

	private float _rotationX = 0;
	

	void Update () {

		//Only move camera if a menu is not open
		if((canvas.activeInHierarchy == false) && (musicCanvas.activeInHierarchy == false) && (userGuide.activeInHierarchy == false))
		{
			
			if(axes == RotationAxis.MouseX) 
			{
				transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
			} 
			else if(axes == RotationAxis.MouseY) 
			{
				_rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
				_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

				float rotationY = transform.localEulerAngles.y;

				transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
			}
		}

		
	}
}
