using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameStates : NetworkBehaviour {

	GameObject goHUD;
	GameObject pongmanNetworkManager;
	GameObject camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("MainCamera");
	}
	
	// Update is called once per frame
	/*void Update () {
		if (gameState == waitingForConnections) {
			if(GameManager.connectedPlayers == GameManager.maximumNumberOfPlayersConnected){
				gameState=playingGame;
				Debug.Log ("set gs to " + gameState + " for player " + GameManager.userName+
				           "isLocalPlayer: " + isLocalPlayer + ", isClient " + isClient + ", isServer: " + isServer);
			}
		}
	}*/

	[ClientRpc]
	public void RpcPlayerJustConnectedToServer(int maxiPlayers, int currPlayers){
		GameManager.maximumNumberOfPlayersConnected = maxiPlayers;
		GameManager.connectedPlayers = currPlayers;
		//Debug.Log ("RPC: " + maxiPlayers.ToString () + ", " + currPlayers.ToString () + ", user=" + GameManager.userName);
		//Debug.Log ("Dbg: " + GameManager.userName + " " + GameManager.maximumNumberOfPlayersConnected + " " +
		//	GameManager.connectedPlayers);
		//Debug.Log ("isLocalPlayer: " + isLocalPlayer + ", isClient " + isClient + ", isServer: " + isServer);
		//Debug.Log(GetComponent<PlayerSyncName>().getPlayerName() + " checking");
		/*if (maxiPlayers==currPlayers) {
			GameManager.setGameState("GAME");
			//GetComponent<NetworkSetup>().translateToSpawn();
		}*/
	}

	void OnGUI(){
		if (isClient) {
			GUI.Label (new Rect(200, 20, 200, 50), 
			           "I am a client");
		}
		if (isServer) {
			GUI.Label (new Rect(400, 20, 200, 50), 
			           "I am a server");
		}
	}

	void Update(){
		if (!isLocalPlayer)
			return;

		if (GameManager.gameState == GameManager.waitingForConnections) {
			if(GameManager.maximumNumberOfPlayersConnected==GameManager.connectedPlayers){
				GameManager.gameState = GameManager.playingGame;
				GetComponent<NetworkSetup>().translateToSpawn();
				camera.GetComponent<CameraScript>().setTrackingMode(true, (int)netId.Value);

			}
		}
	}

	public override void OnStartClient(){
		goHUD = GameObject.Find ("HUD");
		pongmanNetworkManager = GameObject.Find ("NetworkManager");
		base.OnStartClient ();
	}
}
