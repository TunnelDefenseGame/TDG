using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject followMe;
	public Transform focusPoint;

	private Quaternion tempRotation;

	private float zzz;

	// Use this for initialization
	void Start () {
		transform.position = followMe.transform.position;
		transform.rotation = followMe.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = followMe.transform.position;

		//transform.LookAt (focusPoint);

		//tempRotation = transform.rotation;

		//tempRotation.z = followMe.transform.rotation.z;
		//tempRotation.x = followMe.transform.rotation.x;
		//tempRotation.y = followMe.transform.rotation.y;


		transform.rotation = followMe.transform.rotation;
		//transform.rotation = tempRotation;
	}
}
