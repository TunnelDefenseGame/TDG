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
		


		while (SpawnerEnabled) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			timer += Time.deltaTime;
			if (timer >= SpawnInterval) {
				Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			
				yield return new WaitForSeconds(SpawnInterval);
				timer = 0;
				if (SpawnInterval > 1.0f) {
					SpawnInterval -= Mathf.Sqrt (Time.deltaTime);
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
