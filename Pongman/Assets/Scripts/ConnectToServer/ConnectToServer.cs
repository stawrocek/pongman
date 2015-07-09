using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ConnectToServer : MonoBehaviour {

	const int BUTTON_WIDTH = 200;
	const int BUTTON_HEIGHT = 50;
	const int SPACER_HEIGHT = 50;

	string ipAdress="";

	public bool validIp(){
		Match match = Regex.Match(ipAdress, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
		return match.Success;
	}

	public void connect(){
	
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("type: " + GameManager.displayType ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label (GameManager.getShrekt (5, 0), "Client Setup");
		ipAdress = GUI.TextField (GameManager.getShrekt (5, 2), ipAdress, 25);
		if (validIp ()) {
			if (GUI.Button (GameManager.getShrekt(5, 3), "Connect!")) {
				connect();
			}
		} 
		else {
			GUI.Label (GameManager.getShrekt (5, 3), "IP adress seems incorrect");

		}
		if (GUI.Button (GameManager.getShrekt(5, 4), "Return")) {
			Application.LoadLevel("MainMenu");
		}
		
	}
}
