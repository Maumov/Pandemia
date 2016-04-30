using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour
{
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

			if(Vector3.Distance(transform.position,Destination.transform.position) <= 10f ){
				if(isInfected){
					Destination.GetComponent<Country>().AddInfectedPerson();
					Debug.Log(Destination.name + ", got infected via water.");
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

