using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour, IRecycle {

	// To change the sprite each time a obstacle is restarted

	public Sprite[] sprites;

	public Vector2 colliderOffset = Vector2.zero;

	public void Restart(){

		// Randomically pick a sprite to use in the obstacle
		var renderer = GetComponent<SpriteRenderer> ();
		renderer.sprite = sprites [Random.Range (0, sprites.Length)];


		// Resize collider boxes acoording to objects
		var collider = GetComponent<BoxCollider2D> ();
		var size = renderer.bounds.size;
		size.y += colliderOffset.y;

		collider.size = size;
		collider.offset = new Vector2 (-colliderOffset.x, collider.size.y / 2 - colliderOffset.y);
	}

	public void Shutdown(){
	
	}
}
