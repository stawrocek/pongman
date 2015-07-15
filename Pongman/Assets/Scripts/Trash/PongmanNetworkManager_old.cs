using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PongmanNetworkManager_old : MonoBehaviour {

	public GameObject playerPrefab;

	NetworkClient myClient;

	int gamePort = 4444;
	string gameIP = "127.0.0.1";

	public void Spawn(){
		//GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
		//player.GetComponent<NetworkSetup> ().enableComponents ();
		//NetworkServer.Spawn(player);
	}

	public void registerPrefabs(){
		//ClientScene.RegisterPrefab(playerPrefab);
	}

	void setupServer(){
		NetworkServer.Listen(gamePort);
	}

	void setupClient(){
		//registerPrefabs ();
		//Spawn ();

		myClient = new NetworkClient();
		myClient.RegisterHandler(MsgType.Connect, OnConnectedRemotePlayer);
		myClient.RegisterHandler (MsgType.Error, OnErrorRemotePlayer);
		myClient.Connect(gameIP, gamePort);
	}

	void setupLocalClient(){
		//registerPrefabs ();
		//Spawn ();

		myClient = ClientScene.ConnectLocalServer();
		myClient.RegisterHandler(MsgType.Connect, OnConnectedLocalPlayer);
		myClient.RegisterHandler (MsgType.Error, OnErrorLocalPlayer);
	}

	public void OnConnectedLocalPlayer(NetworkMessage netMsg){Debug.Log ("Local client known as " + GameManager.userName + " connected to server");}
	public void OnErrorLocalPlayer(NetworkMessage netMsg){
		Debug.Log ("Remote client known as " + GameManager.userName + " encountered error");
	}
	public void OnConnectedRemotePlayer(NetworkMessage netMsg){Debug.Log ("Local client known as " + GameManager.userName + " connected to server");}
	public void OnErrorRemotePlayer(NetworkMessage netMsg){
		Debug.Log ("Remote client known as " + GameManager.userName + " encountered error");
	}

	void Start () {
		if (GameManager.connectionType == GameManager.server) {
			Debug.Log ("Server & local client under construction for user " + GameManager.userName);
			setupServer();
			setupLocalClient();
		}
		if (GameManager.connectionType == GameManager.client) {
			Debug.Log ("Client under construction for user " + GameManager.userName);
			setupClient();
		}
	}
}
