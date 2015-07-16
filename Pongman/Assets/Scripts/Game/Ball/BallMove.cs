using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour {

	float moveSpeedX = 1;
	float moveSpeedY = 1;

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (moveSpeedX * Time.deltaTime, 0, moveSpeedX * Time.deltaTime);
	}
}
