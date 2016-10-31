using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	Vector3 front;
	public float speed;
	public bool isRegular;
	//float xx;
	//float yy;
	//float zz;

	// Use this for initialization
	void Start () {
		//xx = transform.forward.x;
		//yy = transform.forward.y;
		//zz = transform.forward.z;
		front = new Vector3 (0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += front * Time.deltaTime * speed;
		//transform.position.y += Time.deltaTime * 3f;
	}

	void OnCollisionEnter (Collision col) {
		//Destroy (col.gameObject);
		if (isRegular) {
			Destroy (this.gameObject);
		}
	}
}
