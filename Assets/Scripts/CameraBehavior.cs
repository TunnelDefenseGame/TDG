using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	float timeCounter = 0;
	Vector3 startPos;
	float ratio = 0.75f;
	float circleIndex = 3*Mathf.PI/2;
	float rotationAmount = 180/50f;
	bool rotateLeft = false;
	bool rotateRight = false;


	// Use this for initialization
	void Start () {
	
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


		timeCounter += Time.deltaTime;

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
