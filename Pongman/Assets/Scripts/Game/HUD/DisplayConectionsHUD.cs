using UnityEngine;
using System.Collections;

public class DisplayConectionsHUD : MonoBehaviour {






	// Use this for initialization
	void Start () {
		GameManager.gameState = GameManager.waitingForConnections;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label (new Rect(0, 0, 200, 50), 
		           GameManager.userName + " " + GameManager.gameState);
		string clientsConnectedRatio = GameManager.connectedPlayers.ToString () +
			"/" + GameManager.maximumNumberOfPlayersConnected.ToString();
		if (GameManager.gameState == GameManager.waitingForConnections) {
			GUI.Label (new Rect (0, 20, 200, 50), 
			           clientsConnectedRatio + " clients connected");
		} else if (GameManager.gameState == GameManager.playingGame) {
			GUI.Label (new Rect (0, 70, 200, 50), "Fight!!!");
		}
	}
}
