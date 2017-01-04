using UnityEngine;
using System.Collections;

// Class used to provide GameObjects with the ability to pass through Teleporters

public class Teleport : MonoBehaviour {

	// Triggered when the this component's GameObject hits a Collider that is a Trigger
	void OnTriggerEnter(Collider col) {
		// If the Collider's game object is tagged as a Teleporter
		if (col.gameObject.tag == "Teleporter") {

			// Retrieve the TeleportFunctionality object from the Collider
			TeleportFunctionality teleporter = col.gameObject.GetComponent<TeleportFunctionality>();

			// Make sure we don't get null exception
			// Objects tagged as a teleporter should have TelportFunctionality script attached
			if(teleporter){
				if(teleporter.EndOfLevel) {
					teleporter.LevelCompleted();
				}
				else {
					
					// Transform to the position of the TeleportDestination's target and take it's rotation
					this.transform.position = teleporter.target.transform.position;
					this.transform.rotation = teleporter.target.transform.rotation;
				}

				// Play the audio cue
				teleporter.PlayTelportSound();
			}

		}

	}
}