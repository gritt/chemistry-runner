using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleGameObject : MonoBehaviour {

	 // Unity prefer composition over inheretance
	 // To add little funcionality over big hierarchies

	// When attached to and gameObject, 
	// In attempts to create a object that already exists, restart will be called
	public void Restart() {

		// Allows to make a game object activated or deactivated
		// But still exits in the hierarchy and in the scene
		gameObject.SetActive (true);
	}

	// In attempts to destroy objects, shutdown will be called
	public void Shutdown() {
		gameObject.SetActive (false);
	}
}
