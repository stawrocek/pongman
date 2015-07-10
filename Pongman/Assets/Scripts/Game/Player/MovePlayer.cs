using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (1 * Time.deltaTime, 0, 0);
	}
}
