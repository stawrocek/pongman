using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	Color darkBlue = new Color (0, 51f/255f, 102f/255f);
	Color hardYellow = new Color(238f/255f,221f/255f,130f/255f);

	// Use this for initialization
	void Start () {
		GameManager.setTableLayout (2, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GameManager.drawBorderAroundScene (hardYellow, 10);
		GameManager.drawBoxAroundScene (darkBlue);

		GUI.skin.label.alignment = TextAnchor.MiddleCenter;

		GUI.Label (GameManager.getShrekt(0, 0, 2, 1), "Main Menu");

		GameManager.userName = GUI.TextField (GameManager.getShrekt (1, 2), GameManager.userName, 25);


		if (GUI.Button (GameManager.getShrekt(0, 3), "Connect to server")) {
			GameManager.setClient();
			Application.LoadLevel("ConnectToServer");
		}
		if (GUI.Button (GameManager.getShrekt(1, 3), "Host server")) {
			GameManager.setServer();
			Application.LoadLevel("HostServer");
		}
	}
}
