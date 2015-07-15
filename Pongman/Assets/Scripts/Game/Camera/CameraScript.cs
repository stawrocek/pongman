using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	bool trackPlayer=false;

	public void setTrackingMode(bool mode, int direction){
		trackPlayer = true;
		if (direction == 1) {
			transform.position = GameObject.Find("CameraEast").transform.position;
			GameObject.Find ("SideEast").GetComponent<MeshRenderer>().enabled=false;
		}
		if (direction == 2) {
			transform.position = GameObject.Find("CameraWest").transform.position;
			GameObject.Find ("SideWest").GetComponent<MeshRenderer>().enabled=false;
		}
		if (direction == 3) {
			transform.position = GameObject.Find("CameraSouth").transform.position;
			GameObject.Find ("SideSouth").GetComponent<MeshRenderer>().enabled=false;
		}
		if (direction == 4) {
			transform.position = GameObject.Find("CameraNorth").transform.position;
			GameObject.Find ("SideNorth").GetComponent<MeshRenderer>().enabled=false;
		}
		transform.Translate (0, 11, 0);
		transform.LookAt (new Vector3(0, 0, 0));

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
