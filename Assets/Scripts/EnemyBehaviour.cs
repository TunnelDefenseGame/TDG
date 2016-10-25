using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	//how fast the enemy is moving toward the player
	public static float enemySpeed = 1;

	//how long the explosion lasts from spawn to death
	public float explosionLifetime;

	//array of explosions to randomly choose from
	public GameObject[] explosion;

	//array of powerUps
	public GameObject[] powerUps;
	//The chance that a powerup will appear. Lower number = higher chance
	public int powerUpChance;
	private int randomNumber;
	private int powerUpNumber;
	//random index of powerups to see which one drops
	private int powerUpIndex;


	Vector3 front;

	// Use this for initialization
	void Start () {
		//score = 0;
		front = new Vector3 (0, 0, -enemySpeed);
		//set the number to compare later on for power up dropping
		powerUpNumber = Random.Range (0, powerUpChance);

		//destroy this enemy after a determined time
		Destroy (this.gameObject, 7);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += front * Time.deltaTime * 3f;
	}


	public static void setEnemySpeed (float newEnemySpeed) {
		enemySpeed  = newEnemySpeed;
	}

	public static float getEnemySpeed () {
		return enemySpeed;
	}

	void OnCollisionEnter (Collision col) {
		//Destroy (col.gameObject);
		Destroy (this.gameObject);

		//choose a random explosion to play when the enemy blows up
		int explosionIndex = Random.Range (0, explosion.Length);

		Object ex = Instantiate(explosion[explosionIndex], this.transform.position,this.transform.rotation);
		Destroy (ex, explosionLifetime);
		dropPowerUp ();
		//explosion.
		EnemyManager.score++;
	}

	//determine if we should drop a powerup and drop a random one
	void dropPowerUp () {
		randomNumber = Random.Range (0, powerUpChance);

		if (randomNumber == powerUpNumber) {
			powerUpIndex = Random.Range (0, powerUps.Length);
			Instantiate (powerUps [powerUpIndex], this.transform.position, powerUps[powerUpIndex].transform.rotation);
		}
	}
}
