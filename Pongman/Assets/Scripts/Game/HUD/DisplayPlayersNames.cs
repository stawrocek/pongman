using UnityEngine;
using System.Collections;

public class DisplayPlayersNames : MonoBehaviour {

	public Camera camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GameObject[] allplayers = GameObject.FindGameObjectsWithTag("SomePlayer");
		foreach (GameObject go in allplayers) {
			Vector3 screenPos = camera.WorldToScreenPoint(go.transform.position);
			//(screenPos.x-50), (Screen.height - screenPos.y+10), 100, 50
			Rect r = new Rect(screenPos.x-50, (Screen.height - screenPos.y-50), 100, 50);
			GUI.contentColor = new Color(0.02f, 0.1f, 0.02f);
			GUI.Label(r, go.GetComponent<PlayerSyncName>().getPlayerName() ); 
		}


	}
}
