using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "FrontFace") {
			if (other.gameObject.transform.parent.gameObject.GetComponent<NetworkSetup>().getID()==1) {
				GameManager.invertX ();
				//ball.transform.position = new Vector3(-24.4f, ball.transform.position.y, ball.transform.position.z);
				//pointsChanged (1);
			}
			if (other.gameObject.transform.parent.gameObject.GetComponent<NetworkSetup>().getID()==2) {
				GameManager.invertX ();
				//ball.transform.position = new Vector3(24.4f, ball.transform.position.y, ball.transform.position.z);
				//pointsChanged (2);
			}
			if (other.gameObject.transform.parent.gameObject.GetComponent<NetworkSetup>().getID()==4) {
				GameManager.invertZ();
				//ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, -24.4f);
				//pointsChanged (4);
			}
			if (other.gameObject.transform.parent.gameObject.GetComponent<NetworkSetup>().getID()==3) {
				GameManager.invertZ ();
				//ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, 24.4f);
				//pointsChanged (3);
			}
		}
	}
}
