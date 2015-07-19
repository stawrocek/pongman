using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncPosition : NetworkBehaviour {

	[SyncVar]
	private Vector3 syncPos;

	[SerializeField] Transform myTransform;
	[SerializeField] float lerpRate = 15;
	
	void Update(){
		lerpPosition ();
	}

	void FixedUpdate () {
		TransmitPosition ();
	}

	void lerpPosition()
	{
		if (!isLocalPlayer) {
			myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime*lerpRate);
		}
	}

	[Command]
	void CmdProvidePositionToServer(Vector3 pos){
		syncPos = pos;
	}

	[ClientCallback]
	void TransmitPosition(){
		if (isLocalPlayer) {
			CmdProvidePositionToServer (myTransform.position);
		}
	}
}
