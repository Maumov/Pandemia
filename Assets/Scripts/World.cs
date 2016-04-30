using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour {
	public Country[] Countries;
	public float Population;
	public float Infected;
	public float CurrentPopulation;
	public UnityEngine.UI.Text InfectedTxt;

	// Use this for initialization
	void Start () {
		Countries = GameObject.FindObjectsOfType<Country>();
		SetValues();
	}
	void SetValues(){
		
		Population = 0f;
		Infected = 0f;
		CurrentPopulation = 0f;
		foreach(Country c in Countries){
			Population +=c.population;
			Infected += c.infected;
			CurrentPopulation += c.currentPopulation;
		}

		InfectedTxt.text = ("0000000" + ((int)Infected).ToString()).Substring(((int)Infected).ToString().Length);
	}

	// Update is called once per frame
	void Update () {
		SetValues();
		if(Input.GetButtonDown("Jump")){
			StartGame();
		}

	}
	void StartGame(){
		foreach(Country c in Countries){
			c.AddInfectedPerson();
			Affliction.AfflictionPower = 0.3f;
			Affliction.ExtraCoreChance = 0.3f;
		}
	}
}
