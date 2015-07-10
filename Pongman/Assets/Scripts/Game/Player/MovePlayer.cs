using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotateSpeed = 50f;

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
			transform.Translate (0, 0, Time.deltaTime*moveSpeed);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			//transform.Translate (-Time.deltaTime*moveSpeed, 0, 0);
			transform.Rotate (0, -rotateSpeed * Time.deltaTime, 0);
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			//transform.Translate (Time.deltaTime*moveSpeed, 0, 0);
			transform.Rotate (0, rotateSpeed * Time.deltaTime, 0);
		}
	}
}
