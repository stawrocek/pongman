using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;

		GUI.Label (GameManager.getShrekt(4, 0), "Main Menu");

		if (GUI.Button (GameManager.getShrekt(4, 2), "Connect to server")) {
			GameManager.setClient();
			Application.LoadLevel("ConnectToServer");
		}
		if (GUI.Button (GameManager.getShrekt(4, 3), "Host server")) {
			GameManager.setServer();
			Application.LoadLevel("HostServer");
		}
	}
}
