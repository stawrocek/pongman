using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class BallMove : NetworkBehaviour {

	private GameObject ball;

	// Use this for initialization
	void Start () {
		Debug.Log ("hello");
		ball = GameObject.Find ("Ball(Clone)");
		ball.GetComponent<MeshRenderer>().material.color = Color.blue;
		//ball.transform.position = new Vector3 (10, .5f, -3);
	}

	void checkCollisionsWithBoxes(){
		if (ball.transform.position.x < -24.5f) {
			GameManager.invertX ();
			ball.transform.position = new Vector3(-24.4f, ball.transform.position.y, ball.transform.position.z);
			pointsChanged (1);
		}
		if (ball.transform.position.x > 24.5f) {
			GameManager.invertX ();
			ball.transform.position = new Vector3(24.4f, ball.transform.position.y, ball.transform.position.z);
			pointsChanged (2);
		}
		if (ball.transform.position.z < -24.5f) {
			GameManager.invertZ();
			ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, -24.4f);
			pointsChanged (4);
		}
		if (ball.transform.position.z > 24.5) {
			GameManager.invertZ ();
			ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, 24.4f);
			pointsChanged (3);
		}
	}

	void checkCollisionsWithPlayers(){
		GameObject[] go = GameObject.FindGameObjectsWithTag ("SomePlayer");
		for (int i = 0; i < go.Length; i++) {
			checkWithSinglePlayer(go[i]);
		}
	}

	void checkWithSinglePlayer(GameObject go){
		if (go.GetComponent<NetworkSetup> ().getID () == 1) {

		}
		if (go.GetComponent<NetworkSetup> ().getID () == 2) {
			
		}
		if (go.GetComponent<NetworkSetup> ().getID () == 3) {
			
		}
		if (go.GetComponent<NetworkSetup> ().getID () == 4) {
			
		}
	}

	void Update(){
		if (isServer) {
			ball.transform.Translate (GameManager.moveSpeedX * Time.deltaTime, 0, GameManager.moveSpeedZ * Time.deltaTime);
			ball.GetComponent<SyncBallPosition>().setVar(ball.transform.position);
			checkCollisionsWithBoxes ();
			checkCollisionsWithPlayers ();
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
