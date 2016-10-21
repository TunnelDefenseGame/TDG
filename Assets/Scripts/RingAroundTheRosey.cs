using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RingAroundTheRosey : MonoBehaviour {

	Transform Ship_2;
	public GameObject m_shotPrefab;

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
	Vector3 startPos;
	//Vector3 tunnelPos;
	float startX;
	float startY;
	float startZ;
	float x;
	float y;
	float z;
	float ratio = 0.75f;
	float circleIndex = 3*Mathf.PI/2;
	float rotationAmount = 180/50f;
	bool rotateLeft = false;
	bool rotateRight = false;

	// Use this for initialization
	void Start () {
		startPos = GameObject.Find("nave").transform.position;
		//tunnelPos = GameObject.Find("Updatedv3tunnel").transform.position;

		startX = startPos.x;
		startY = startPos.y;
		startZ = startPos.z;

		transform.position = playerPoints [currentIndex].position;
		transform.rotation = playerPoints [currentIndex].rotation;
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
		x = ratio * (Mathf.Cos (circleIndex)) + startX;
		y = ratio * (Mathf.Sin (circleIndex)) + startY + ratio;
		z = startZ;
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
		if (Input.GetKeyDown(KeyCode.Space) && isOverHeated == false) {
			GameObject go = GameObject.Instantiate(m_shotPrefab, transform.position, Quaternion.identity) as GameObject;
			GameObject.Destroy(go, 3f);

			//increase the heat of the gun and check to see if it is overheated
			currentGunHeat += 1.0f;

			if (currentGunHeat >= maxGunHeat) {
				isOverHeated = true;
			}
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
}
