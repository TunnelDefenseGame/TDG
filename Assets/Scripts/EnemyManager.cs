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
	public float spawnTime;
	public Transform[] spawnPoints;

	public static int score;
	public Text scoreText;

	private float timer;

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
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			timer += Time.deltaTime;
			if (timer >= startSpawnInterval) {

				//spawn an enemy at one of the random locations
				Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);

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

	//Update the score of the game
	void setScoreText () {
		scoreText.text = "Score: " + score.ToString ();
		//print (score);
	}
}
