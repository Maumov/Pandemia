using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float speed = 1f;
	public float vertical, horizontal,forward;
	public GameObject World;
	public float maxY, minY, maxZ, minZ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Inputs();
		if(transform.position.y >= maxY && vertical > 0f){
			vertical = 0f;
		}else if(transform.position.y <= minY && vertical < 0f){
			vertical = 0f;
		}
		if(transform.localPosition.z >= maxZ && forward > 0f){
			forward = 0f;
		}else if(transform.localPosition.z <= minZ && forward < 0f){
			forward = 0f;
		}
		transform.Translate(0f,vertical * speed * Time.deltaTime,forward * 25f* speed * Time.deltaTime);

		//transform.Translate(horizontal  * speed * Time.deltaTime,vertical * speed * Time.deltaTime,0f);
		transform.LookAt(World.transform,transform.up);
	}
	void Inputs(){
		vertical = Input.GetAxisRaw("Vertical");
		//horizontal = Input.GetAxisRaw("Horizontal");
		forward = Input.GetAxisRaw("Mouse ScrollWheel");
	}
}
