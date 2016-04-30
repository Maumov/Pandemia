using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TrailController : MonoBehaviour {
	public float FollowTime = 5f;
	float time;
	public int amount;
	public GameObject targetToFollow;
	public GameObject Segment;
	List<TrailRenderer> Segments;
	int current = 0;
	bool sw;
	// Use this for initialization
	void Start () {
		Segments = new List<TrailRenderer>();
		for(int i = 0; i < amount; i ++){
			GameObject g = (GameObject)Instantiate(Segment,transform.position,Quaternion.identity);
			g.transform.parent = transform.parent;
			Segments.Add(g.GetComponent<TrailRenderer>());

		}
		time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time > FollowTime){
			time = 0f;
			sw = !sw;
			if(sw){
				current +=1;
				if(current == Segments.Count){
					current = 0;
				}
				Segments[current].Clear();
			}

		}
		Follow();

	}
	void Follow(){
		transform.position = targetToFollow.transform.position;	
		if(sw){
			Segments[current].transform.position = transform.position;	
		}
	}
}
