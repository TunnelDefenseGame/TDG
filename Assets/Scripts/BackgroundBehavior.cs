using UnityEngine;
using System.Collections;

public class BackgroundBehavior : MonoBehaviour {

	public Texture2D[] textures;

	// Use this for initialization
	void Start () {
		//select a random texture from the list of textures
		int textureIndex = Random.Range (0, textures.Length);


		GetComponent<Renderer>().material.mainTexture = textures[textureIndex];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
