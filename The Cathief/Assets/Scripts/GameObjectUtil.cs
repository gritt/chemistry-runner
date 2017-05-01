using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtil {

	private static Dictionary<RecycleGameObject, ObjectPull> pools = new Dictionary<RecycleGameObject, ObjectPull> ();

	// Object pull
	// Objects don't get destroyed, they get recycled / reconfigured and used again

	// pos : where in the game scene the object will be created
	public static GameObject Instantiate(GameObject prefab, Vector3 pos) {

		GameObject instance = null;

		var recycledScript = prefab.GetComponent<RecycleGameObject> ();

		if (recycledScript != null) {
			var pool = GetObjectPool (recycledScript);
			instance = pool.NextObject (pos).gameObject;
		
		} else {
			instance = GameObject.Instantiate (prefab);
			instance.transform.position = pos;			
		}

		return instance;
	}

	public static void Destroy(GameObject gameObject) {

		var recycledGameObject = gameObject.GetComponent<RecycleGameObject> ();

		if (recycledGameObject != null) {
			recycledGameObject.Shutdown ();

		} else {
			GameObject.Destroy (gameObject);
		}
	}

	// Key = prefab
	// Value = pool
	private static ObjectPull GetObjectPool(RecycleGameObject reference) {

		ObjectPull pool = null;

		if (pools.ContainsKey (reference)) {
			pool = pools [reference];
		
		} else {
			
			var poolContainer = new GameObject (reference.gameObject.name + "ObjectPool");

			pool = poolContainer.AddComponent<ObjectPull> ();
			pool.prefab = reference;

			pools.Add (reference, pool);
		}

		return pool;
	}
}
