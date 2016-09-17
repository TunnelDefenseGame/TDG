﻿using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	Vector3 front;

	// Use this for initialization
	void Start () {
		front = new Vector3 (0, 0, -1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += front * Time.deltaTime * 3f;
		if (gameObject.name == "Enemy(Clone)") {
			Destroy (gameObject, 10);
		}
	}
}
