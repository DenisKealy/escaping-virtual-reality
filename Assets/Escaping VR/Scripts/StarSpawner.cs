using UnityEngine;
using System.Collections;


// Class used to spawn falling stars in Level 2
public class StarSpawner : MonoBehaviour {

	// Public members assigned in Unity Editor
	public float timeBetweenStars;
	public Rigidbody starPrefab;

	// Countdown timer until next star is spawned
	private float spawnTimer;


	void Start () {
	
		spawnTimer = timeBetweenStars;

	}

	void Update () {

		// Update timer
		spawnTimer -= Time.deltaTime;

		// If timer is less than zero
		if(spawnTimer < 0) {
			// Spawn a star & reset the timer
			Instantiate(starPrefab, this.transform.position, this.transform.rotation);
			spawnTimer = timeBetweenStars;
		}

	}

}
