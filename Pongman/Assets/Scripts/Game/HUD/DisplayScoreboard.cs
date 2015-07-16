using UnityEngine;
using System.Collections;

public class DisplayScoreboard : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GameManager.gameState == GameManager.playingGame) {
			GameObject[] go = GameObject.FindGameObjectsWithTag("SomePlayer");
			GUI.Label (new Rect(Screen.width - 200, 10, 200, 25), go[0].GetComponent<PlayerSyncName>().getPlayerName()+
			           ": " + go[0].GetComponent<PlayerSyncScore>().getPlayerScore().ToString());
			GUI.Label (new Rect(Screen.width - 200, 40, 200, 25), go[1].GetComponent<PlayerSyncName>().getPlayerName()+
			           ": " + go[1].GetComponent<PlayerSyncScore>().getPlayerScore().ToString());
			if(GameManager.maximumNumberOfPlayersConnected==4){
				GUI.Label (new Rect(Screen.width - 200, 70, 200, 25), go[2].GetComponent<PlayerSyncName>().getPlayerName()+
				           ": " + go[2].GetComponent<PlayerSyncScore>().getPlayerScore().ToString());
				GUI.Label (new Rect(Screen.width - 200, 100, 200, 25), go[3].GetComponent<PlayerSyncName>().getPlayerName()+
				           ": " + go[3].GetComponent<PlayerSyncScore>().getPlayerScore().ToString());
			}
		}
	}
}
