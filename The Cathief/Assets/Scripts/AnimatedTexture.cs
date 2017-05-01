using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTexture : MonoBehaviour {


	public Vector2 speed = Vector2.zero;

	private Vector2 offset = Vector2.zero;

	private Material material;


	void Start () {

		// Get a reference to the material that is attached to the quad object
		material = GetComponent<Renderer> ().material;

		// Name of the default texture
		offset = material.GetTextureOffset ("_MainTex");
	}
	
	void Update () {

		// The delta time represents the difference in time 
		// Between one frame rendering to the next
		offset += speed * Time.deltaTime;

		material.SetTextureOffset ("_MainTex", offset);
	}
}
