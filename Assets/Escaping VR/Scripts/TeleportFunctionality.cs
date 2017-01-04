using UnityEngine;
using System.Collections;


// Class used to turn GameObjects into teleporters
public class TeleportFunctionality : MonoBehaviour {

	// Public member to be assigned in the Unity Editor
	public GameObject target;

	// Is this a teleporter to another level
	public bool EndOfLevel = false;
	

	public void PlayTelportSound() {
		AudioSource teleportSound = GetComponent<AudioSource>();
		teleportSound.Play();
	}

	public void LevelCompleted() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

}
