using UnityEngine;
using System.Collections;

public class WorldMovement : MonoBehaviour {
	public float speed = 1f;
	float vertical, horizontal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Inputs();
		transform.Rotate(0f,horizontal * speed * Time.deltaTime,0f);
	}
	void Inputs(){
		//vertical = Input.GetAxisRaw("Vertical");
		horizontal = Input.GetAxisRaw("Horizontal");
	}
}
