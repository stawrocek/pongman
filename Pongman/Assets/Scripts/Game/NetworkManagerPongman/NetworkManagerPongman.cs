using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkManagerPongman : NetworkManager {
	
	//virtual methods

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		if (GameManager.maximumNumberOfPlayersConnected == GameManager.connectedPlayers) {
			Debug.Log ("Game is full :(");
			return;
		}
		Debug.Log ("Spawning player known as " + GameManager.userName + " on the server!!!");
		GameObject player = (GameObject)GameObject.Instantiate(playerPrefab, 
		        new Vector3(Random.Range(-24, 24), 0, Random.Range(-24, 24))
		                                                       , Quaternion.identity);
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

		GameManager.connectedPlayers++;
		Debug.Log ("NetworkManager::OnServerAddPlayer");
		//think about it:
		GameObject.Find ("Player(Clone)").GetComponent<GameStates>().RpcPlayerJustConnectedToServer (GameManager.maximumNumberOfPlayersConnected, GameManager.connectedPlayers);
	}

	public override void OnStartClient(NetworkClient client)
	{
		//Debug.Log("Starting Client... for user " + GameManager.userName);
		
		//GameObject thisClientObject = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
		//thisClientObject.name = "ClientFromScript";
		//DontDestroyOnLoad(thisClientObject);

		base.OnStartClient (client);
	}

	void setupHost(){
		StartHost ();
	}

	void setupClient(){
		StartClient ();
	}

	/*public override void OnStartClient(){
		Debug.Log ("Client for user known as " + GameManager.userName + " just started, info from" +
			"NetworkManagerPongman");
	}*/

	void Start () {
		if (GameManager.connectionType == GameManager.server) {
			Debug.Log ("Server & local client under construction for user " + GameManager.userName);
			setupHost();
		}
		if (GameManager.connectionType == GameManager.client) {
			Debug.Log ("Client under construction for user " + GameManager.userName);
			setupClient();
		}
	}
}
