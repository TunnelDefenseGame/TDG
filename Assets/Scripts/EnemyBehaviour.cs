using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public static float enemySpeed = 1;

	public GameObject explosion;

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
	}

	public static void setEnemySpeed (float newEnemySpeed) {
		enemySpeed  = newEnemySpeed;
	}

	public static float getEnemySpeed () {
		return enemySpeed;
	}

	void OnCollisionEnter (Collision col) {
		Destroy (col.gameObject);
		Destroy (this.gameObject);
		Instantiate(explosion, this.transform.position,this.transform.rotation);
		//explosion.
		EnemyManager.score++;
	}


}
