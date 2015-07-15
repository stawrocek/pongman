using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncColor : NetworkBehaviour {

	[SyncVar (hook = "syncColorChanged")]
	Color syncPlayerColor;

	public void changeRealColor(Color color){
		TransmitColor (color);
	}

	[Command]
	void CmdProvideNewColorToServer(Color color){
		syncPlayerColor = color;
		GetComponent<Renderer>().material.color = color;
	}

	[ClientCallback]
	void TransmitColor(Color c){
		CmdProvideNewColorToServer(c);
	}

	[Client]
	protected virtual void syncColorChanged(Color c)
	{
		syncPlayerColor = c;
		GetComponent<Renderer>().material.color = c;
	}
}
