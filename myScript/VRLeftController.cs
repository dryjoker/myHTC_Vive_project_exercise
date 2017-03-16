using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VRLeftController : MonoBehaviour {
	public SteamVR_TrackedObject leftController;
	public GameObject controllerInfo;

	bool isTriggerdPress = false;
	bool isTouchPadTouch = false;
	bool isTouchPadPress = false;
	bool isGripPress = false;
	bool isManuPress = false;
	Vector2 touchpadPosition = new Vector2 ();


	float pressValue = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (leftController == null)
			return;

		var device = SteamVR_Controller.Input ((int)leftController.index);

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			pressValue = device.GetAxis (Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
			print ("Hello Triggerd Press : "+ "Value:" + pressValue);
		}
		string infor = "Left Controller Information: \n";

		myTriggerDetect (device);
		myTouchPadDetect (device);
		myGripDetect (device);
		myManuDetect (device);

		infor += "Press Trigger :" + isTriggerdPress 
			+ "\nTrigger Press Value :"+ pressValue 
			+ "\nTouchPad Press:" + isTouchPadPress 
			+ "\nTouchpad touch:" + isTouchPadTouch
			+ "\nTouchpad Position:" + touchpadPosition 
			+ "\nGrip Press:" + isGripPress 
			+ "\nManu Press:" + isManuPress;

		controllerInfo.GetComponent<TextMesh> ().text = infor;
	}

	void myTriggerDetect(SteamVR_Controller.Device device)
	{
		if(device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
		{
			pressValue = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
			isTriggerdPress = true;
		}
		else
		{
			isTriggerdPress = false;
			pressValue = 0;
		}
	}

	void myTouchPadDetect(SteamVR_Controller.Device device)
	{
		if (device.GetPress (SteamVR_Controller.ButtonMask.Touchpad)) {
			isTouchPadPress = true;
		} 
		else {
			isTouchPadPress = false;
		}
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Touchpad)) {
			isTouchPadTouch = true;
			touchpadPosition = device.GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis0);
		} 
		else 
		{
			isTouchPadTouch = false;
			touchpadPosition = new Vector2 (0,0);
		}
	}
	void myGripDetect(SteamVR_Controller.Device device)
	{
		if (device.GetPress (SteamVR_Controller.ButtonMask.Grip)) {
			isGripPress = true;
		} 
		else {
			isGripPress = false;
		}
	}

	void myManuDetect(SteamVR_Controller.Device device)
	{
		if (device.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			isManuPress = true;
		} 
		else {
			isManuPress = false;
		}
	}
}
