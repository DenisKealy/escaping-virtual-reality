using UnityEngine;
using System.Collections;

public class HoloChamberListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.M))
		{
			Application.LoadLevel("Holo Moon");
		}
		if(Input.GetKeyDown(KeyCode.K))
		{
			Application.LoadLevel("Holo Campfire");
		}
		if(Input.GetKeyDown(KeyCode.H))
		{
			Application.LoadLevel("Holo Chamber");
		}
	}
}
