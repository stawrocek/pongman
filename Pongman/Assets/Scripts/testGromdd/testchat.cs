using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class chat : NetworkBehaviour { 
	[SyncVar] string LastMessage;
	[SerializeField] string LastDeliveredMessage;
	string  NewMessage;
	Text MessageBox;
	// Use this for initialization
	// Update is called once per frame
	void start()
	{
		MessageBox = GameObject.Find ("Chat2").GetComponent<Text>();
		MessageBox.text = "";
	}
	void Update () 
	{
		if (Input.GetKey (KeyCode.KeypadEnter))
			ChatUpdate ();
		IsUpdated ();
	}
	void IsUpdated (){
		if (LastMessage == LastDeliveredMessage)
		{
			//MessageBox = LastMessage;
			MessageBox.text+=LastMessage;
			LastDeliveredMessage=LastMessage;
		}
	}
	void ChatUpdate ()
	{
		CmdMessage ();
	}

	void OnGUI() 
	{
		NewMessage =GUI.TextField (new Rect(0, 300, 0, 15), NewMessage, 128);
	}

	[Command]
	void CmdMessage ()
	{
		LastMessage="["+Time.time+"]"+GameManager.userName+NewMessage;
	}
}