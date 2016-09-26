﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RingAroundTheRosey : MonoBehaviour {

	Transform Ship_2;
	public GameObject m_shotPrefab;


	public Slider heatSlider; 
	public Image Fill;
	public float maxGunHeat;
	private float currentGunHeat;
	public float coolDownAmount;
	private bool isOverHeated = false;


	public float cooledDown;

	float timeCounter = 0;
	Vector3 startPos;
	//Vector3 tunnelPos;
	float startX;
	float startY;
	float startZ;
	float ratio = 0.75f;
	float circleIndex = 3*Mathf.PI/2;
	float rotationAmount = 180/50f;
	bool rotateLeft = false;
	bool rotateRight = false;

	// Use this for initialization
	void Start () {
		startPos = GameObject.Find("Ship_2").transform.position;
		//tunnelPos = GameObject.Find("Updatedv3tunnel").transform.position;

		startX = startPos.x;
		startY = startPos.y;
		startZ = startPos.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow) & !(Input.GetKey(KeyCode.RightArrow))) {
			circleIndex -= Mathf.PI/50f;
			rotateLeft = true;
			//if(circleIndex < 0) {
			//	circleIndex += 360;
			//}
		}
		if ((Input.GetKey(KeyCode.RightArrow)) & !(Input.GetKey(KeyCode.LeftArrow))) {
			circleIndex += Mathf.PI/50f;
			rotateRight = true;
			//if(circleIndex > 360) {
			//	circleIndex -= 360;
			//}
		}
		if (Input.GetKeyDown(KeyCode.Space) && isOverHeated == false) {
			GameObject go = GameObject.Instantiate(m_shotPrefab, transform.position, Quaternion.identity) as GameObject;
			GameObject.Destroy(go, 3f);

			//increase the heat of the gun and check to see if it is overheated
			currentGunHeat += 1.0f;

			if (currentGunHeat >= maxGunHeat) {
				isOverHeated = true;
			}
		}
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

		//heatSlider.value = val;
		Fill.color = Color.Lerp (Color.blue, Color.red, currentGunHeat / maxGunHeat);

		//print (currentGunHeat);
		heatSlider.value = currentGunHeat;

		timeCounter += Time.deltaTime;
		float x = ratio * (Mathf.Cos (circleIndex)) + startX;
		float y = ratio * (Mathf.Sin (circleIndex)) + startY + ratio;
		float z = startZ;
		transform.position = new Vector3 (x, y, z);

		if (rotateLeft) {
			transform.Rotate(new Vector3(0, 0, -rotationAmount), Space.World);
			rotateLeft = false;
			rotateRight = false;
		} else if (rotateRight) {
			transform.Rotate(new Vector3(0, 0, rotationAmount), Space.World);
			rotateLeft = false;
			rotateRight = false;
		}
	}
}
