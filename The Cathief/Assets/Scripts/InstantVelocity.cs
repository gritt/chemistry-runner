using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantVelocity : MonoBehaviour {

	public Vector2 velocity = Vector2.zero;

	private Rigidbody2D body2d;

	// To happen early on the scripts lifecycle, available on start
	void Awake() {

		body2d = GetComponent<Rigidbody2D> ();
	}

	// Making physics calculations, only gets called limited number of times per frame
	void FixedUpdate() {
		body2d.velocity = velocity;
	}
}
