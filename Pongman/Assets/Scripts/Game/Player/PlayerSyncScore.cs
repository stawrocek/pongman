using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncScore : NetworkBehaviour {
	[SyncVar (hook = "syncScoreChanged")]
	int syncPlayerScore;

	public override void OnStartClient ()
	{
		syncPlayerScore = 0;
		base.OnStartClient ();
	}

	public void changeRealScore(int scr){
		TransmitScore (scr);
	}

	public void addPoint(){
		TransmitScore (syncPlayerScore + 1);
		//Debug.Log ("transmit: " + syncPlayerScore + 1);
	}
	
	public int getPlayerScore(){
		return syncPlayerScore;
	}
	
	[Command]
	void CmdProvideNewScoreToServer(int scr){
		//if (!isLocalPlayer)
		//	return;

		syncPlayerScore = scr;
		//GetComponent<Renderer>().material.color = color;
	}
	
	[ClientCallback]
	void TransmitScore(int scr){
		CmdProvideNewScoreToServer(scr);
	}

	[Client]
	void syncScoreChanged(int scr)
	{
		syncPlayerScore = scr;
		//GetComponent<Renderer>().material.color = c;
	}
}
