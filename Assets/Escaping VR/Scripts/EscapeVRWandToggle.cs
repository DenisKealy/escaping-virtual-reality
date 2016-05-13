using UnityEngine;
using System.Collections;

public class EscapeVRWandToggle : MonoBehaviour {
	
	public GameObject wandToToggle;

	private RUISSkeletonWand skeletonWandComponent;
	private RUISWandSelector wandSelectorComponent;


	// Use this for initialization
	void Start () {
		skeletonWandComponent = wandToToggle.GetComponent<RUISSkeletonWand>();
		Debug.Log(skeletonWandComponent.ToString());
		wandSelectorComponent = wandToToggle.GetComponent<RUISWandSelector>();
		Debug.Log(wandSelectorComponent.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
		// Use getkeydown to ensure this code only gets executed in one frame, every time T is pressed.
		if (Input.GetKeyDown(KeyCode.T)) {

			// If there is an object highlighted - this will allow it to keep it's momentum at the time the wand is turned off
			// This allows the player to let go of items with more consistency than the kinect fist gesture
			if(wandSelectorComponent.Selection)
				//End Selection called in VR code
				wandSelectorComponent.EndSelection();

			// Switch from Active to Inactive or vice versa
			wandToToggle.SetActive(!wandToToggle.activeSelf);
			skeletonWandComponent.enabled = !skeletonWandComponent.enabled;
			wandSelectorComponent.enabled = !wandSelectorComponent.enabled;
		}

	}
}
