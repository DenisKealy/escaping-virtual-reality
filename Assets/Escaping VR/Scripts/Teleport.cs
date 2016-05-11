using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// Triggered when the this component's GameObject hits a Collider that is a Trigger
	void OnTriggerEnter(Collider col) {
		// If the Collider's game object is tagged as a Teleporter
		if (col.gameObject.tag == "Teleporter") {

			// Retrieve the TeleportDestination object from the Collider
			TeleportDestination destination = col.gameObject.GetComponent<TeleportDestination>();

			// Transform to the position of the TeleportDestination's target and take it's rotation
			this.transform.position = destination.target.transform.position;
			this.transform.rotation = destination.target.transform.rotation;
		}

	}
}