using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	//Should the enemies still be spawning or are we done here?
	public bool SpawnerEnabled;

	//interval between spawn times for enemies
	public float SpawnInterval;

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
		

		//if the game is still going, keep spawning enemies
		while (SpawnerEnabled) {

			//pick a random number between 0 and the number of spawn locations
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			timer += Time.deltaTime;
			if (timer >= SpawnInterval) {

				//spawn an enemy at one of the random locations
				Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);

				//wait
				yield return new WaitForSeconds(SpawnInterval);

				//reset the timer
				timer = 0;

				//increase the speed of the spawning of enemies over time.
				if (SpawnInterval > 1.0f) {
					SpawnInterval -= Mathf.Sqrt (Time.deltaTime);
				} else if (SpawnInterval < 1.0f) {
					SpawnInterval = 1.0f;
				}

				//increase the speed of the enemies over time
				if (EnemyBehaviour.getEnemySpeed() < 3.0f) {
					EnemyBehaviour.setEnemySpeed (Mathf.Sqrt (Time.deltaTime));
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
