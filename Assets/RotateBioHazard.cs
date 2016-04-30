using UnityEngine;
using System.Collections;

public class RotateBioHazard : MonoBehaviour {
	public float Speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0F,0f,Speed * Time.deltaTime);
	}
}
