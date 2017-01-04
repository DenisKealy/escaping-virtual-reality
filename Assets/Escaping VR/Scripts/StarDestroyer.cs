using UnityEngine;
using System.Collections;

public class StarDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Star") {
			col.gameObject.SetActive(false);
		}
	}
}
