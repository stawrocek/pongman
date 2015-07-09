using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	const int BUTTON_WIDTH = 200;
	const int BUTTON_HEIGHT = 50;
	const int SPACER_HEIGHT = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width/2 - BUTTON_WIDTH / 2, Screen.height/2 - BUTTON_HEIGHT / 2 - SPACER_HEIGHT/2, BUTTON_WIDTH, 
		                        BUTTON_HEIGHT), "Connect to server")) {
			Debug.Log ("Connect to server");
		}
		if (GUI.Button (new Rect (Screen.width/2 - BUTTON_WIDTH / 2, Screen.height/2 + SPACER_HEIGHT/2, BUTTON_WIDTH, 
		                          BUTTON_HEIGHT), "Host server")) {
			Debug.Log ("Host server");
		}
		
	}
}
