using UnityEngine;
using System.Collections;

public class TunnelBehavior : MonoBehaviour {

	public float rotationSpeed;
	
	// Update is called once per frame
	void Update () {
		//tunnel will rotate around the Z axis at the speed given for this specific tunnel
		transform.Rotate(new Vector3(0, 0, rotationSpeed), Space.World);
	}
}
