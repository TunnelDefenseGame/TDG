using UnityEngine;
using System.Collections;

public class ActivePowerUp : MonoBehaviour {

	public static string activePowerUp = "";

	//How long the enemies slow down for
	public float sandClockTime;
	private float tempSandTime;
	//speed of the enemies when the powerUp is active
	public static float sandClockSpeed = 1.0f;

	//is this powerUp active?
	private bool sandClockActive = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (activePowerUp == "sandclock" || sandClockActive == true) {
			sandClockActive = true;
			float tempSpeed;
			//reset the actve powerUp
			if (activePowerUp == "sandclock") {
				tempSandTime = sandClockTime;
				activePowerUp = "";
				//slow down the enemy speed
				EnemyManager.setSandClockActive (true);

			}
			//the active time should be subtracted from
			tempSandTime -= Time.deltaTime;
			//reset the enemey speed if the time is up
			if (tempSandTime <= 0.0f) {
				EnemyManager.setSandClockActive (false);
				sandClockActive = false;
			}


		}
	}

	public static void setActivePowerUp (string newActive) {
		activePowerUp = newActive;
	}
}
