using UnityEngine;
using System.Collections;

public class RingAroundTheRosey : MonoBehaviour {

	float timeCounter = 0;
	Vector3 startPos;
	Vector3 tunnelPos;
	float startX;
	float startY;
	float startZ;
	float ratio = 0.675f;
	float circleIndex = 3*Mathf.PI/2;
	float rotationAmount = 180/50f;
	bool rotateLeft = false;
	bool rotateRight = false;

	// Use this for initialization
	void Start () {
		startPos = GameObject.Find("Ship_2").transform.position;
		tunnelPos = GameObject.Find("Updatedv3tunnel").transform.position;

		startX = startPos.x;
		startY = startPos.y;
		startZ = startPos.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			circleIndex -= Mathf.PI/50f;
			rotateLeft = true;
			//if(circleIndex < 0) {
			//	circleIndex += 360;
			//}
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			circleIndex += Mathf.PI/50f;
			rotateRight = true;
			//if(circleIndex > 360) {
			//	circleIndex -= 360;
			//}
		}


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
