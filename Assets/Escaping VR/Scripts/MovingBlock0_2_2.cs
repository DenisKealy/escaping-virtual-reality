using UnityEngine;
using System.Collections;

public class MovingBlock0_2_2 : MonoBehaviour {

	private bool blockIsShrinking = false;
	private bool playerHasFallen = false;
	private Vector3 originalScale;

	void Awake(){
		originalScale =  this.transform.localScale;
	}

	void OnTriggerEnter(Collider col) {

		//Debug.Log("Detected Trigger at MovingBlock0_2_2");
		
		if(col.gameObject.tag == "Player"){

			//Debug.Log("Detected Player at MovingBlock0_2_2");
			blockIsShrinking = true;

		}
	}

	void Update(){

		if(blockIsShrinking){
			// Don't scale the block past 0
			if(this.transform.localScale.y > 0)
				shrinkBlockUpdate();
		}
	
	}

	private void shrinkBlockUpdate() {
		this.transform.localScale += new Vector3(0, -0.03f * Time.deltaTime, 0);
	}

	public void resetBlockUpdate() {
		this.transform.localScale = originalScale;
		blockIsShrinking = false;
	}
}
