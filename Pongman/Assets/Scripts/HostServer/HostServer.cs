using UnityEngine;
using System.Collections;

public class HostServer : MonoBehaviour {

	const int BUTTON_WIDTH = 200;
	const int BUTTON_HEIGHT = 50;
	const int SPACER_HEIGHT = 50;

	// Use this for initialization
	void Start () {
		Debug.Log ("type: " + GameManager.displayType ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		/*GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label (GameManager.getShrekt (4, 0), "Server Setup");
		if (GUI.Button (GameManager.getShrekt(4, 2), "Host!")) {
			Application.LoadLevel("Pongman");
		}
		if (GUI.Button (GameManager.getShrekt(4, 3), "Return")) {
			Application.LoadLevel("MainMenu");
		}*/
		
	}
}
