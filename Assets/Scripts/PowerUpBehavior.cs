using UnityEngine;
using System.Collections;

public class PowerUpBehavior : MonoBehaviour {

	//speed of the powerUp will be the same as the ship
	public float speed = EnemyBehaviour.enemySpeed;

	//the direction of movement
	private Vector3 front;

	// Use this for initialization
	void Start () {
		front = new Vector3 (0, 0, -speed);
		Destroy (this.gameObject, 7);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += front * Time.deltaTime * 3f;
	}

	void OnCollisionEnter (Collision col) {
		Destroy (this.gameObject);
	}
}
