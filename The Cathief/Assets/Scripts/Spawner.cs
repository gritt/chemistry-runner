using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] prefabs;

	public float delay = 2.0f;

	// To Spawn object in a random time range
	public Vector2 delayRange = new Vector2 (1, 2);

	// To Stop spawning objects
	public bool active = true;


	// Objects will have a timer attached to them
	// When the timer goes out, it will spawn a new obtacle
	void Start () {

		ResetDelay ();

		// Coroutine / Run indepentent of the normal loop, 
		StartCoroutine (EnemyGenerator ());
	}

	IEnumerator EnemyGenerator() {
	
		// When it gets called, waits for a certain amount of time to execute
		yield return new WaitForSeconds (delay);

		if (active) {
		
			var newTransform = transform;

			Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position, Quaternion.identity);

			ResetDelay ();
		}

		StartCoroutine (EnemyGenerator ());
	}

	void ResetDelay() {
		delay = Random.Range (delayRange.x, delayRange.y);
	}
}
