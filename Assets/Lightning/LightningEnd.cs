using UnityEngine;
using System.Collections;

public class LightningEnd : MonoBehaviour {

	//this file should create and move the endpoint of the lightning randomly within a range

	//should take in a float length and 2 degree values to randomly choose between

	//The program will take the random degree chosen, choose an X and Y length that give the length chosen

	public float length;
	[Space(20)]
	public float lowDegree;
	public float highDegree;
	[Space(20)]
	public Transform startZ;

	
	private float degree;
	private float x;
	private float y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		degree = Random.Range (lowDegree, highDegree);
		degree = (degree * Mathf.PI / 180);
		x = length * Mathf.Cos (degree);
		y = length * Mathf.Sin (degree);
		transform.position = new Vector3(x, y, startZ.position.z);
	}
}
