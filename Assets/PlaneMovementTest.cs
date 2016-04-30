using UnityEngine;
using System.Collections;

public class PlaneMovementTest : MonoBehaviour {
	public GameObject target;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target.transform,transform.up);
		transform.Translate(speed * Time.deltaTime,0f,0f);
	}
}
