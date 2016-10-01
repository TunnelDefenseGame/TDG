using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 1f;
	public Transform[] spawnPoints;

	public static int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		setScoreText ();
	}

	// Update is called once per frame
	void Update () {
		setScoreText ();
	}


	void Spawn () {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
	
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}


	void setScoreText () {
		scoreText.text = "Score: " + score.ToString ();
		//print (score);
	}
}
