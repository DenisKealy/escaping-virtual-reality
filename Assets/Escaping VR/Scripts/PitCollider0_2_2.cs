using UnityEngine;
using System.Collections;

public class PitCollider0_2_2 : MonoBehaviour {

	public MovingBlock0_2_2 block;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Player") {
			Debug.Log ("Player Fell 0_2_2");
			block.resetBlockUpdate();
		}
	}
}
