using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public static float enemySpeed = 1;

	Vector3 front;

	// Use this for initialization
	void Start () {
		//score = 0;
		front = new Vector3 (0, 0, -enemySpeed);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += front * Time.deltaTime * 3f;
		if (gameObject.name == "Enemy(Clone)") {
			Destroy (gameObject, 10);
		}
		print (enemySpeed);
	}

	public static void setEnemySpeed (float increase) {
		enemySpeed += increase;
		if (enemySpeed > 3.0f) {
			enemySpeed = 3.0f;
		}
	}

	public static float getEnemySpeed () {
		return enemySpeed;
	}

	void OnCollisionEnter (Collision col) {
		Destroy (col.gameObject);
		Destroy (this.gameObject);
		EnemyManager.score++;
	}


}
