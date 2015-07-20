using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class HostServer : MonoBehaviour {

	const int BUTTON_WIDTH = 200;
	const int BUTTON_HEIGHT = 50;
	const int SPACER_HEIGHT = 50;

	Color darkBlue = new Color (0, 51f/255f, 102f/255f);

	string ipAdress="";
	//Color lightYellow = new Color(238f/255f,221f/255f,130f/255f);
	public bool validIp(){
		Match match = Regex.Match(ipAdress, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
		return match.Success;
	}
	// Use this for initialization
	void Start () {
		GameManager.setTableLayout (1, 6);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void hostGame(int howManyPlayers){
		GameManager.maximumNumberOfPlayersConnected = howManyPlayers;
		GameManager.serverIP = ipAdress;
		Application.LoadLevel("Pongman");
	}

	void OnGUI() {
		GameManager.drawBoxAroundScene (darkBlue);

		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label (GameManager.getShrekt (0, 0), "Server Setup for user\n'" + GameManager.userName  +"'");
		ipAdress = GUI.TextField (GameManager.getShrekt (0, 2), ipAdress, 25);
		if (validIp ()) {
			if (GUI.Button (GameManager.getShrekt(0, 3), "Host game for 2 users! (FFA)")) {
				hostGame(2);
			}
			if (GUI.Button (GameManager.getShrekt(0, 4), "Host game for 4 users! (FFA)")) {
				hostGame (4);
			}
		}

		if (GUI.Button (GameManager.getShrekt(0, 5), "Return")) {
			Application.LoadLevel("MainMenu");
		}
		
	}
}
