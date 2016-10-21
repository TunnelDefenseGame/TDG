using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	//Should the enemies still be spawning or are we done here?
	public bool SpawnerEnabled;

	//interval between spawn times for enemies at the beginning of the game and the max speed
	public float startSpawnInterval;
	public float endSpawnInterval;

	public float maxEnemySpeed;

	public GameObject enemy;

	//the particle system to play before an enemy appears
	public GameObject teleport;
	//lifetime of the teleport particle system
	public float teleportLifetime;

	public float spawnTime;
	public Transform[] spawnPoints;

	public static int score;
	public Text scoreText;

	private float timer;

	private int spawnPointIndex;

	// Use this for initialization
	void Start () {
		SpawnerEnabled = true;
		score = 0;
		//Start this function
		StartCoroutine (Spawn ());
		//InvokeRepeating ("Spawn", spawnTime, spawnTime);
		setScoreText ();
	}

	// Update is called once per frame
	void Update () {
		setScoreText ();
	}


	IEnumerator Spawn () {

		float temp;

		//if the game is still going, keep spawning enemies
		while (SpawnerEnabled) {

			//pick a random number between 0 and the number of spawn locations
			int tempint = Random.Range (0, spawnPoints.Length);

			spawnPointIndex = tempint;

			timer += Time.deltaTime;
			if (timer >= startSpawnInterval) {

				//spawn the particle system, wait, and spawn the ship
				Invoke ("spawnTeleport", 0);
				Invoke ("spawnEnemy", teleportLifetime);




				//wait
				yield return new WaitForSeconds(startSpawnInterval);

				//reset the timer
				timer = 0;

				//increase the speed of the spawning of enemies over time.
				if (startSpawnInterval > endSpawnInterval) {
					startSpawnInterval -= Mathf.Sqrt (Time.deltaTime);
				} else if (startSpawnInterval < endSpawnInterval) {
					startSpawnInterval = endSpawnInterval;
				}


				temp = EnemyBehaviour.getEnemySpeed ();
				//increase the speed of the enemies over time, cap out at the max speed
				if (temp < maxEnemySpeed) {
					EnemyBehaviour.setEnemySpeed (temp += Mathf.Sqrt (Time.deltaTime));
				} else if (temp > maxEnemySpeed) {
					EnemyBehaviour.setEnemySpeed (maxEnemySpeed);
				}
			}
		}
	}

	//spawn the teleport particle system and kill it before the enemy appears
	void spawnTeleport () {
		Object tempobj = Instantiate (teleport, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		//kill the teleport particle system
		Destroy (tempobj, teleportLifetime);
	}

	//spawn the enemy ship
	void spawnEnemy () {
		//spawn an enemy at one of the random locations
		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}


	//Update the score of the game
	void setScoreText () {
		scoreText.text = "Score: " + score.ToString ();
		//print (score);
	}
}
