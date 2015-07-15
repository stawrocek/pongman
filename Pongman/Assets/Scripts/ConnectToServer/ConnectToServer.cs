using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ConnectToServer : MonoBehaviour {

	const int BUTTON_WIDTH = 200;
	const int BUTTON_HEIGHT = 50;
	const int SPACER_HEIGHT = 50;
	Color darkBlue = new Color (0, 51f/255f, 102f/255f);
	//Color lightYellow = new Color(238f/255f,221f/255f,130f/255f);
	string ipAdress="";

	public bool validIp(){
		Match match = Regex.Match(ipAdress, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
		return match.Success;
	}

	public void connect(){
		GameManager.serverIP = ipAdress;
		Application.LoadLevel("Pongman");
	}

	// Use this for initialization
	void Start () {
		GameManager.setTableLayout (1, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		//GameManager.drawBorderAroundScene (lightYellow, 10);
		GameManager.drawBoxAroundScene (darkBlue);

		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label (GameManager.getShrekt (0, 0), "Client Setup for user\n'" + GameManager.userName  +"'");
		ipAdress = GUI.TextField (GameManager.getShrekt (0, 2), ipAdress, 25);
		if (validIp ()) {
			if (GUI.Button (GameManager.getShrekt(0, 3), "Connect!")) {
				connect();
			}
		} 
		else {
			GUI.Label (GameManager.getShrekt (0, 3), "IP adress seems incorrect");

		}
		if (GUI.Button (GameManager.getShrekt(0, 4), "Return")) {
			Application.LoadLevel("MainMenu");
		}
	}
}
