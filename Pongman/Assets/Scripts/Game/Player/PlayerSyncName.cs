using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncName : NetworkBehaviour {

	[SyncVar (hook = "syncNameChanged")]
	string syncPlayerName;

	public void changeRealName(string str){
		TransmitName (str);
	}

	public string getPlayerName(){
		return syncPlayerName;
	}

	[Command]
	void CmdProvideNewNameToServer(string str){
		syncPlayerName = str;
		//GetComponent<Renderer>().material.color = color;
	}
	
	[ClientCallback]
	void TransmitName(string str){
		CmdProvideNewNameToServer(str);
	}
	
	[Client]
	void syncNameChanged(string str)
	{
		syncPlayerName = str;
		//GetComponent<Renderer>().material.color = c;
	}
}
