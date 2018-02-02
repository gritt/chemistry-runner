using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledBackground : MonoBehaviour {

	public int textureSize = 32;
	public bool scaleHorizontally = true;
	public bool scaleVertically = true;

	void Start () {

		// How many tiles fit in the current screen height and width, 
		// How many times it has to repeat	

		var newWidth = !scaleHorizontally ? 1 : Mathf.Ceil (Screen.width / (textureSize * PixelPerfectCamera.scale));
		var newHeight = !scaleVertically ? 1 : Mathf.Ceil (Screen.height / (textureSize * PixelPerfectCamera.scale));

		// Always use Vector3 for scaling
		transform.localScale = new Vector3 (newWidth * textureSize, newHeight * textureSize, 1);

		GetComponent<Renderer> ().material.mainTextureScale = new Vector3 (newWidth, newHeight, 1);
	}
}
