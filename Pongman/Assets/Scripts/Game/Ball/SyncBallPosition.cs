using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SyncBallPosition : NetworkBehaviour {

	[SyncVar]
	private Vector3 syncPos;
	
	private Transform myTransform;
	[SerializeField] float lerpRate = 15;
	private Vector3 lastPos;

	private float threshold=0.5f;

	public void setVar(Vector3 vec){
		syncPos = vec;
	}

	void Start(){
		myTransform = GameObject.Find ("Ball(Clone)").transform;
		//myTransform.position = new Vector3 (10, .5f, -3);
		//lastPos = myTransform.position;
	}

	void Update(){
		lerpPosition ();
	}
	
	void FixedUpdate () {
		//TransmitPosition ();
	}
	
	void lerpPosition()
	{
		myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime*lerpRate);
		//myTransform.position = syncPos;
	}

	/*[Command]
	void CmdProvidePositionToServer(Vector3 pos){
		syncPos = pos;
	}
	
	[ClientCallback]
	void TransmitPosition(){
		if (isLocalPlayer) {
			CmdProvidePositionToServer (myTransform.position);
		}
	}*/
}
