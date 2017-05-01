using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPull : MonoBehaviour {

	/**
	 * In essence, an object pool is simply gonna be a class that manages instances that it creates. 
	 * 
	 * In the case of a pool, it'll also manage whether the objects are inactive or active, 
	 * so whenever you request a new game object from the pool, it'll look through its list, 
	 * see which ones have been already created but are not in use, and return one of those. 
	 * 
	 * If there aren't any inactive objects, it'll create a new one for you.
	 * */

	public RecycleGameObject prefab;

	// Key value, able dynamically add or remove
	private List<RecycleGameObject> poolInstances = new List<RecycleGameObject> ();

	// Allow to create the instance when needed
	// Private, so other classes cant call to create on the fly
	// Position where wanna to create the instance
	private RecycleGameObject CreateInstance(Vector3 pos) {

		// Only place when GameObject gets instanciated directly
		var clone = GameObject.Instantiate(prefab);

		// New position for the object
		clone.transform.position = pos;

		// Equal the game object tranform that our object pool is attached to
		clone.transform.parent = transform;

		poolInstances.Add (clone);

		return clone;
	}

	// Return instances when requested
	public RecycleGameObject NextObject(Vector3 pos) {
	
		RecycleGameObject instance = null;

		instance = CreateInstance (pos);

		instance.Restart ();

		return instance;
	}
}