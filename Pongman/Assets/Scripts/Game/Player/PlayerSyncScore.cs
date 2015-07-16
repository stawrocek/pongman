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
	
	public int getPlayerScore(){
		return syncPlayerScore;
	}
	
	[Command]
	void CmdProvideNewScoreToServer(int scr){
		syncPlayerScore = scr;
		//GetComponent<Renderer>().material.color = color;
	}
	
	[ClientCallback]
	void TransmitScore(int scr){
		CmdProvideNewScoreToServer(scr);
	}
	
	[Client]
	protected virtual void syncScoreChanged(int scr)
	{
		syncPlayerScore = scr;
		//GetComponent<Renderer>().material.color = c;
	}
}
