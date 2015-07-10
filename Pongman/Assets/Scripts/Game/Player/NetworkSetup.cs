using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkSetup : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			GetComponent<MovePlayer>().enabled = true;
		}
	}
}
