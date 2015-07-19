using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class MovePlayer : MonoBehaviour {

	public float moveSpeed = 10f;         
	public float rotateSpeed = 50f;
	Color[] colorArray = new Color[] {Color.black, Color.white, Color.red, Color.green, Color.yellow};

	int netID=-10;

	GameObject camera;

	public void moveOnlyInWaiting(){
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate (0, 0, Time.deltaTime*moveSpeed);
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate (0, 0, -Time.deltaTime*moveSpeed);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate (-Time.deltaTime*moveSpeed, 0, 0);
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate (Time.deltaTime*moveSpeed, 0, 0);
		}
	}

	public void moveOnlyInGame(){
		//Debug.Log ("game!!! " + netID.ToString ());
		if(netID==-10)return;
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			if(netID==1){
				transform.Translate (0, 0, moveSpeed*Time.deltaTime, Space.World);
				camera.transform.Translate(0, 0, moveSpeed*Time.deltaTime, Space.World);
			}
			if(netID==2){
				transform.Translate (0, 0, -moveSpeed*Time.deltaTime, Space.World);
				camera.transform.Translate(0, 0, -moveSpeed*Time.deltaTime, Space.World);
			}
			if(netID==3){
				transform.Translate (moveSpeed*Time.deltaTime, 0, 0, Space.World);
				camera.transform.Translate(moveSpeed*Time.deltaTime, 0, 0, Space.World);
			}
			if(netID==4){
				transform.Translate (-moveSpeed*Time.deltaTime, 0, 0, Space.World);
				camera.transform.Translate(-moveSpeed*Time.deltaTime, 0, 0, Space.World);
			}
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			if(netID==1){
				transform.Translate (0, 0, -moveSpeed*Time.deltaTime, Space.World);
				camera.transform.Translate(0, 0, -moveSpeed*Time.deltaTime, Space.World);
			}
			if(netID==2){
				transform.Translate (0, 0, moveSpeed*Time.deltaTime, Space.World);
				camera.transform.Translate(0, 0, moveSpeed*Time.deltaTime, Space.World);
			}
			if(netID==3){
				transform.Translate (-moveSpeed*Time.deltaTime, 0, 0, Space.World);
				camera.transform.Translate(-moveSpeed*Time.deltaTime, 0, 0, Space.World);
			}
			if(netID==4){
				transform.Translate (moveSpeed*Time.deltaTime, 0, 0, Space.World);
				camera.transform.Translate(moveSpeed*Time.deltaTime, 0, 0, Space.World);
			}
		}
		//camera.transform.LookAt
	}

	public void moveInBoth(){
		if(Input.GetKey(KeyCode.Alpha1))
		{
			GetComponent<PlayerSyncColor>().changeRealColor(colorArray[0]);
		}
		else if(Input.GetKey(KeyCode.Alpha2))
		{
			GetComponent<PlayerSyncColor>().changeRealColor(colorArray[1]);
		}
		else if(Input.GetKey(KeyCode.Alpha3))
		{
			GetComponent<PlayerSyncColor>().changeRealColor(colorArray[2]);
		}
		else if(Input.GetKey(KeyCode.Alpha4))
		{
			GetComponent<PlayerSyncColor>().changeRealColor(colorArray[3]);
		}
		else if(Input.GetKey(KeyCode.Alpha5))
		{
			GetComponent<PlayerSyncColor>().changeRealColor(colorArray[4]);
		}
		else if(Input.GetKeyDown(KeyCode.N))
		{
			GameObject[] allplayers = GameObject.FindGameObjectsWithTag("SomePlayer");
			Debug.Log ("players (by 'n'): ");
			for (int i = 0; i < allplayers.Length; i++) {
				//Debug.Log ("name: " + allplayers[i].GetComponent<PlayerSyncName>().getPlayerName());
				//Debug.Log (allplayers[i].name);
				Debug.Log (allplayers[i].GetComponent<PlayerSyncName>().getPlayerName());
			}
		}
		else if(Input.GetKeyDown(KeyCode.D))
		{
			GameObject[] allplayers = GameObject.FindGameObjectsWithTag("SomePlayer");
			for (int i = 0; i < allplayers.Length; i++) {
				allplayers[i].GetComponent<NetworkSetup>().dispNetId();
			}
		}
	}

	public void setNetId(int _netID){
		netID = _netID;
		//Debug.Log ("new net id= " + netID);
	}

	void Start(){
		camera = GameObject.Find ("MainCamera");
	}

	void Update () {
		if (GameManager.gameState == GameManager.playingGame) {
			moveOnlyInGame();	
		} 
		else if (GameManager.gameState == GameManager.waitingForConnections) {
			moveOnlyInWaiting();
		}

		moveInBoth ();
	}
}
