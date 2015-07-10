using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//((MeshRenderer)this.GetComponent<MeshRenderer>()).SetC

		GetComponent<Renderer> ().material.color = Color.blue;//Color(Random.Range(0.0,1.0),Random.Range(0.0,1.0),Random.Range(0.0,1.0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
