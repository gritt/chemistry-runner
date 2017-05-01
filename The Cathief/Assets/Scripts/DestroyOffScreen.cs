using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour {

	// How far it neds to be offscreen before gets deleted
	public float offset = 16f;

	// Is object off the screen? and when needs to be deleted / true false
	private bool offscren;
	private float offscrenX = 0;
	private Rigidbody2D body2d;

	void Awake(){

		body2d = GetComponent<Rigidbody2D> ();		
	}

	// Use this for initialization
	void Start () {

		offscrenX = (Screen.width / PixelPerfectCamera.pixelToUnit) / 2 + offset;
	}

	// Update is called once per frame
	void Update () {

		var posX = transform.position.x;
		var dirX = body2d.velocity.x;

		// Absolute value, convert to positve
		if (Mathf.Abs (posX) > offscrenX) {

			if (dirX < 0 && posX < -offscrenX) {
				offscren = true;
			}else if (dirX > 0 && posX > offscrenX) {
				offscren = true;
			}

		} else {
			offscren = false;
		}

		if (offscren) {
			OnOutOfBounds ();
		}
	}

	public void OnOutOfBounds () {
		offscren = false;
		Destroy (gameObject);
	}
}