using UnityEngine;
using System.Collections;

public class HostServer : MonoBehaviour {

	const int BUTTON_WIDTH = 200;
	const int BUTTON_HEIGHT = 50;
	const int SPACER_HEIGHT = 50;

	Color darkBlue = new Color (0, 51f/255f, 102f/255f);
	Color lightYellow = new Color(238f/255f,221f/255f,130f/255f);

	// Use this for initialization
	void Start () {
		GameManager.setTableLayout (1, 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GameManager.drawBoxAroundScene (darkBlue);

		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label (GameManager.getShrekt (0, 0), "Server Setup for user\n'" + GameManager.userName  +"'");
		if (GUI.Button (GameManager.getShrekt(0, 2), "Host!")) {
			Application.LoadLevel("Pongman");
		}
		if (GUI.Button (GameManager.getShrekt(0, 3), "Return")) {
			Application.LoadLevel("MainMenu");
		}
		
	}
}
