using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class MovePlayer : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotateSpeed = 50f;
	Color[] colorArray = new Color[] {Color.black, Color.white, Color.red, Color.green, Color.yellow};
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetAxis ()) {
		
		}
		transform.Translate (1 * Time.deltaTime, 0, 0);*/
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate (0, 0, Time.deltaTime*moveSpeed);
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate (0, 0, -Time.deltaTime*moveSpeed);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate (-Time.deltaTime*moveSpeed, 0, 0);
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate (Time.deltaTime*moveSpeed, 0, 0);
		}
		else if(Input.GetKey(KeyCode.Alpha1))
		{
			GetComponent<Renderer>().material.color = colorArray[0];
		}
		else if(Input.GetKey(KeyCode.Alpha2))
		{
			GetComponent<Renderer>().material.color = colorArray[1];
		}
		else if(Input.GetKey(KeyCode.Alpha3))
		{
			GetComponent<Renderer>().material.color = colorArray[2];
		}
		else if(Input.GetKey(KeyCode.Alpha4))
		{
			GetComponent<Renderer>().material.color = colorArray[3];
		}
		else if(Input.GetKey(KeyCode.Alpha5))
		{
			GetComponent<Renderer>().material.color = colorArray[4];
		}
	}
}
