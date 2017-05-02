using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecycle{

	void Restart ();
	void Shutdown ();

}

public class RecycleGameObject : MonoBehaviour {

	 // Unity prefer composition over inheretance
	 // To add little funcionality over big hierarchies

	private List<IRecycle> recycleComponents;

	public void Awake() {

		var components = GetComponents<MonoBehaviour> ();

		recycleComponents = new List<IRecycle> ();

		foreach (var component in components) {
		
			if (component is IRecycle) {
				recycleComponents.Add (component as IRecycle);
			}
		}
	}

	// When attached to and gameObject, 
	// In attempts to create a object that already exists, restart will be called
	public void Restart() {

		// Allows to make a game object activated or deactivated
		// But still exits in the hierarchy and in the scene
		gameObject.SetActive (true);


		foreach (var component in recycleComponents) {
			component.Restart ();
		}
	}

	// In attempts to destroy objects, shutdown will be called
	public void Shutdown() {

		gameObject.SetActive (false);

		foreach (var component in recycleComponents) {
			component.Shutdown ();
		}
	}
}
