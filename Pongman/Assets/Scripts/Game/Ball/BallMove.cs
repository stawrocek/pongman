using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class BallMove : NetworkBehaviour {

	public float moveSpeedX = 10;
	public float moveSpeedZ = 10;

	private GameObject ball;

	public void invertX(){
		moveSpeedX *= -1;
	}

	public void invertZ(){
		moveSpeedZ *= -1;
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("hello");
		ball = GameObject.Find ("Ball(Clone)");
		ball.GetComponent<MeshRenderer>().material.color = Color.blue;
		ball.transform.position = new Vector3 (10, .5f, -3);
	}

	void checkCollisionsWithBoxes(){
		if (ball.transform.position.x < -24.5f) {
			invertX ();
			ball.transform.position = new Vector3(-24.4f, ball.transform.position.y, ball.transform.position.z);
			pointsChanged (1);
		}
		if (ball.transform.position.x > 24.5f) {
			invertX ();
			ball.transform.position = new Vector3(24.4f, ball.transform.position.y, ball.transform.position.z);
			pointsChanged (2);
		}
		if (ball.transform.position.z < -24.5f) {
			invertZ();
			ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, -24.4f);
			pointsChanged (4);
		}
		if (ball.transform.position.z > 24.5) {
			invertZ ();
			ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, 24.4f);
			pointsChanged (3);
		}
	}

	void Update(){
		if (isServer) {
			ball.transform.Translate (moveSpeedX * Time.deltaTime, 0, moveSpeedZ * Time.deltaTime);
			ball.GetComponent<SyncBallPosition>().setVar(ball.transform.position);
			checkCollisionsWithBoxes ();
		}
	}

	void pointsChanged(int clIdx){
		GameObject[] go = GameObject.FindGameObjectsWithTag ("SomePlayer");
		for (int i = 0; i < go.Length; i++) {
			if(go[i].GetComponent<NetworkSetup>().getID() == clIdx){
				go[i].GetComponent<PlayerSyncScore>().addPoint();
				return;
			}
		}
	}
}
