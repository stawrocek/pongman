using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public int server = 1337, client = 42;
	static public int connectionType = 0;

	static public void setServer(){
		connectionType = server;
	}

	static public void setClient(){
		connectionType = client;
	}

	static public string displayType(){
		if (connectionType == server)
			return "Server";
		else if (connectionType == client)
			return "Client";
		return "unknown type";
	}

	static public int BUTTON_WIDTH = 200;
	static public int BUTTON_HEIGHT = 50;
	static public int SPACER = 25;


	static public Rect getShrekt(int total, int idx)    //adds rectangular widget with index = idx (idx from 0) into vertical "table" with 'total' number of same shaped elements
	{ 
		int TOTAL_HEIGHT = (total-1)*SPACER + total * BUTTON_HEIGHT;
		return new Rect (Screen.width / 2 - BUTTON_WIDTH / 2, 
		            Screen.height / 2 - TOTAL_HEIGHT/2 + idx * BUTTON_HEIGHT + (idx - 1) * SPACER,
		            BUTTON_WIDTH,
		            BUTTON_HEIGHT);
	} 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
