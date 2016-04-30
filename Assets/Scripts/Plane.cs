using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {
	public GameObject Origin, Destination;
	public bool isInfected;
	public float Speed;
	bool start = false;
	// Use this for initialization
	void Start () {
		transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
	}
	
	// Update is called once per frame
	void Update () {
		if(start){
			
			transform.position += (Destination.transform.position - Origin.transform.position)/Vector3.Distance(Destination.transform.position,Origin.transform.position) * Speed * Time.deltaTime;
//			transform.position = new Vector3(
//				Mathf.Clamp(transform.position.x < Origin.transform.position.x ?transform.position.x:Origin.transform.position.x ,transform.position.x < Origin.transform.position.x ?Origin.transform.position.x:transform.position.x,Destination.transform.position.x),
//				Mathf.Clamp(transform.position.y < Origin.transform.position.y ?transform.position.y:Origin.transform.position.y ,transform.position.y < Origin.transform.position.y ?Origin.transform.position.y:transform.position.y,Destination.transform.position.y),
//				Mathf.Clamp(transform.position.z,Origin.transform.position.z,Destination.transform.position.z));
			if(Vector3.Distance(transform.position,Destination.transform.position) <= 10f ){
				if(isInfected){
					Destination.GetComponent<Country>().AddInfectedPerson();
					Debug.Log(Destination.name + ", got infected via air.");
					start = false;

				}
				Destroy(gameObject);
			}	
		}

	}
	public void SetValues(GameObject or,GameObject des, bool infected){
		Origin = or;
		Destination = des;
		isInfected = infected;
		transform.position = Origin.transform.position;
		start = true;
	}

}
