using UnityEngine;
using System.Collections;

//Class to control the Skeleton Wand's attached to the cahracter. Only Right hand wand is implemented correctly.
//Always leave twoWands false for now.

public class WandControls : MonoBehaviour {

	// Assigned in the Unity Editor
	public GameObject rightHandWand;
	public GameObject leftHandWand;
	
	private RUISWandSelector leftWandSelectorComponent;
	private RUISWandSelector rightWandSelectorComponent;
	

	[Tooltip("Two wands or just one (right hand).")] 
	public bool twoWands;


	private float lastWandOnOffAxisValue = 0;


	void Start () {

		if(rightHandWand)
			rightWandSelectorComponent = rightHandWand.GetComponent<RUISWandSelector>();

		if(leftHandWand)
			leftWandSelectorComponent = leftHandWand.GetComponent<RUISWandSelector>();
	}

	void Update () {

		// If we have two wands (not supported)
		if(twoWands){

			if(Input.GetAxis("WandOnOff") == 1 && lastWandOnOffAxisValue != Input.GetAxis("WandOnOff")) {


				TwoWandToggleOnOff();
				if(leftHandWand.activeSelf || rightHandWand.activeSelf)
				{
					ReleaseSelectedObjects();
				}

			}
		}
		// This is the current implementation
		else{

			if(Input.GetAxis("WandOnOff") == 1){
				if(!rightHandWand.activeSelf){
					// If the wand is off and the trigger is held, turn it on.
					WandToggleOnOff();
				}
			
			}
			else {
				if(rightHandWand.activeSelf) {
					// If the trigger is released and the wand is on, turn it off
					// and release any selected object.
					ReleaseSelectedObjects();
					WandToggleOnOff();
				}
			}

		}
		lastWandOnOffAxisValue = Input.GetAxis("WandOnOff");

	}

	// Toggle wand feature - Return: Was the wand turned on or off
	public bool WandToggleOnOff (){

		// Switch from Active to Inactive or vice versa
		rightHandWand.SetActive(!rightHandWand.activeSelf);
		// Return whether the wand is now on or off
		return rightHandWand.activeSelf;


	}

	// Toggle wand feature - Return: Was the wand turned on or off
	public bool TwoWandToggleOnOff (){
		
		// Switch from Active to Inactive or vice versa
		rightHandWand.SetActive(!rightHandWand.activeSelf);
		leftHandWand.SetActive(!leftHandWand.activeSelf);
		// Return whether the wand is now on or off
		return rightHandWand.activeSelf && leftHandWand.activeSelf;
		
		
	}


	// If there is an object highlighted - this will allow it to
	// keep it's momentum at the time the wand is turned off
	// This allows the player to let go of items with more consistency
	// than the kinect fist gesture

	public void ReleaseSelectedObjects() {

		//if(leftWandSelectorComponent.Selection)
			//leftWandSelectorComponent.EndSelection();

		if(rightWandSelectorComponent.Selection)
			rightWandSelectorComponent.EndSelection();
	}

	public void LeftHandGrabCheck(){
		if(Input.GetAxis ("LeftWandFist") == 1){
			if(!leftWandSelectorComponent.Selection){
				//If there is no selection
			}
		}
	}

	public void LeftHandReleaseCheck(){
		if(Input.GetAxis ("LeftWandFist") <= 0){
			if(leftWandSelectorComponent.Selection){
				//leftWandSelectorComponent.EndSelection();
			}
		}
	}

}
