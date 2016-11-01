using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RingAroundTheRosey : MonoBehaviour {

	Transform Ship_2;
	public GameObject m_shotPrefab;
	public GameObject spiritBomb;

	//are any of the arrow keys being held down?
	private bool keydown = false;

	public Slider heatSlider; 
	public Image Fill;
	public float maxGunHeat;
	private float currentGunHeat;
	public float coolDownAmount;
	private bool isOverHeated = false;

	public Transform[] playerPoints;
	private int currentIndex = 0;

	//speed of the moving from point to point
	public float speed;

	public float cooledDown;

	float timeCounter = 0;
	float circleIndex = 3*Mathf.PI/2;
	bool rotateLeft = false;
	bool rotateRight = false;

	//the string that lets ActivePowerUp know what to do
	private static string activePowerUp;

	// Use this for initialization
	void Start () {

		transform.position = playerPoints [currentIndex].position;
		transform.rotation = playerPoints [currentIndex].rotation;

		activePowerUp = "";
	}
	
	// Update is called once per frame
	void Update () {

		moveAndRotate ();

		shoot ();

		coolDown ();

		updateSlider ();

	}

	void moveAndRotate () {

		float step = speed * Time.deltaTime;

		if (Input.touchCount > 0) {

			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				print ("touch began");
			}
			if (Input.GetTouch (0).phase == TouchPhase.Moved) {
				print ("touch moved");
			}
			if (Input.GetTouch (0).phase == TouchPhase.Ended) {
				print ("touch ended");
			}
			//if (Input.GetTouch (0).
		}


		if (Input.GetKey(KeyCode.LeftArrow) & !(Input.GetKey(KeyCode.RightArrow)) & (keydown == false)) {
			circleIndex -= Mathf.PI/50f;
			rotateLeft = true;
			keydown = true;
		}
		if ((Input.GetKey(KeyCode.RightArrow)) & !(Input.GetKey(KeyCode.LeftArrow)) & (keydown == false)) {
			circleIndex += Mathf.PI/50f;
			rotateRight = true;
			keydown = true;
		}
		if (!(Input.GetKey(KeyCode.RightArrow)) & !(Input.GetKey(KeyCode.LeftArrow))) {
			keydown = false;
		}

		timeCounter += Time.deltaTime;
		//transform.position = new Vector3 (x, y, z);

		if (rotateLeft) {
			//transform.Rotate(new Vector3(0, 0, -rotationAmount), Space.World);
			currentIndex--;
			if (currentIndex == -1) {
				currentIndex = playerPoints.Length - 1;
			}
			//transform.position = playerPoints [currentIndex].position;
			//transform.rotation = playerPoints [currentIndex].rotation;
			//transform.position = Vector3.MoveTowards(transform.position, playerPoints [currentIndex].position, step);
			rotateLeft = false;
			rotateRight = false;
		
		} else if (rotateRight) {
			//transform.Rotate(new Vector3(0, 0, rotationAmount), Space.World);
			currentIndex++;
			if (currentIndex == playerPoints.Length) {
				currentIndex = 0;
			}
			//transform.position = playerPoints [currentIndex].position;
			//transform.rotation = playerPoints [currentIndex].rotation;
			//transform.position = Vector3.MoveTowards(transform.position, playerPoints [currentIndex].position, step);

			rotateLeft = false;
			rotateRight = false;
		}
		transform.position = Vector3.MoveTowards(transform.position, playerPoints [currentIndex].position, step);
		transform.rotation = Quaternion.Slerp(transform.rotation, playerPoints [currentIndex].rotation, step * 2);
	}




	void shoot () {
		//if user wants to fire a regular shot, fire a regular shot
		if (Input.GetKeyDown(KeyCode.Space) && isOverHeated == false) {
			fireShot (m_shotPrefab, 3f);
		}

		//if they want to fire a special shot, fire a special shot
		if (Input.GetKeyDown(KeyCode.S) && isOverHeated == false && activePowerUp == "rocket") {
			fireShot (spiritBomb, 10f);
			//remove this as active powerUp since it is one use
			activePowerUp = "";
		}
	}
		
	void fireShot (GameObject gogo, float life) {
		GameObject go = GameObject.Instantiate(gogo, transform.position, Quaternion.identity) as GameObject;
		GameObject.Destroy(go, life);

		//increase the heat of the gun and check to see if it is overheated
		currentGunHeat += 1.0f;

		if (currentGunHeat >= maxGunHeat) {
			isOverHeated = true;
		}			
	}


	void coolDown () {
		//take away the cooldown amount, should be less than what is added to it for each shot
		if (currentGunHeat > 0f) {
			currentGunHeat -= coolDownAmount;
		} else {
			currentGunHeat = 0f;
		}
		//check to see if the gun has cooled down enough to use again
		if ((isOverHeated) && currentGunHeat <= cooledDown) {
			isOverHeated = false;
		}
	}

	void updateSlider () {
		//heatSlider.value = val;
		Fill.color = Color.Lerp (Color.blue, Color.red, currentGunHeat / maxGunHeat);

		//print (currentGunHeat);
		heatSlider.value = currentGunHeat;
	}



	public int getPositionIndex () {
		return currentIndex;
	}

	//when it collides with something
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.name == "SandClock(Clone)") {
			activePowerUp = "sandclock";
			ActivePowerUp.setActivePowerUp (activePowerUp);
		} 
		else if (col.gameObject.name == "Rocket(Clone)") {
			activePowerUp = "rocket";
			print ("rocket hit detected");
			ActivePowerUp.setActivePowerUp (activePowerUp);
		}
	}
}
