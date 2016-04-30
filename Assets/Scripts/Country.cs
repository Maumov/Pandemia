using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Climate {Warm, Cold, Hot}
public enum ClimateType {Wet, Dry, None}
public enum Wealth {Poor, Rich, None}
public enum Demography {Urban, Rural, None} 

public class Country : MonoBehaviour {
	public string Name = "CountryName";
	public float population = 1000000f;
	public float currentPopulation;
	public float infected = 1f;

	public Climate climate;
	public ClimateType type;
	public Wealth wealth;
	public Demography demography;

	public float time = 1f;
	public float Area;
	public Country[] ConnectedToLand;
	public Country[] ConnectedToAir;
	public Country[] ConnectedToWater;
	public float lastAirSent,lastLandSent,lastWaterSent;
	public float AirSentGap,LandSentGap,WaterSentGap;
	public List<AfflictionCore> ACores;
	float LastTimeCoreAdded = 0f;

	bool started = false;

	public GameObject PlanePrefab;
	// Use this for initialization
	void Start () {
		SetValues();

	}
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(started){
			
			DoRound();	
		}
		AirDispersion();
		LandDispersion();
	}
	[ContextMenu ("Do Round")]
	public void DoRound(){
		foreach(AfflictionCore ac in ACores){
			infected += ac.AfflictionDispersion(this) + ac.PopulationDispersion(this);	

		}
		if(time - LastTimeCoreAdded >=7f){
			if(AfflictionCore.ChanceOfNewCore()){
				AddInfectedPerson();	
			}
			LastTimeCoreAdded = time;
		}
		infected = Mathf.Clamp(infected,0f,population);

		if(infected == population){
			Debug.Log("Done");
			Debug.Log("Tiempo" + time / 60);
			started = false;
		}
	}
	//Population to be afflicted
	public float PopulationAfflicted(){
		return HealthyPopulation() * ProbabilityOfContagion() * PopulationDensity();
	}
	//Chance to be afflicted
	public float ProbabilityOfContagion(){
		return infected / currentPopulation;
	}
	//Remaining Healthy population
	public float HealthyPopulation(){
		return currentPopulation - infected;
	}
	public float PopulationDensity(){
		return currentPopulation / Area;
	}
	public void SetValues(){
		currentPopulation = population;
		ACores = new List<AfflictionCore>();
		lastAirSent = 0f;
		lastLandSent = 0f;
		lastWaterSent = 0f;
	}
	public void LandDispersion(){
		float random = Random.Range(0f,1f);
		if(time - lastLandSent >= LandSentGap ){
			lastLandSent = time;
			if( ConnectedToLand.Length > 0 ){
				SendLand(random < ProbabilityOfContagion() * Affliction.LandDispersion);	
			}

		}
	}
	public void SendLand(bool isInfected){
		if(isInfected){
			int countryToGo = Random.Range(0,ConnectedToLand.Length);
			ConnectedToLand[countryToGo].AddInfectedPerson();
			Debug.Log(ConnectedToLand[countryToGo].name + ", got infected via land.");
		}
	}
	public void AirDispersion(){
		float random = Random.Range(0f,1f);
		if(time - lastAirSent >= AirSentGap){
			lastAirSent = time;
			if(ConnectedToAir.Length> 0){
				SendAir(random < ProbabilityOfContagion() * Affliction.AirDispersion);	
			}

		}

	}
	public void SendAir(bool isInfected){
		int countryToGo = Random.Range(0,ConnectedToAir.Length);
		GameObject g = (GameObject)Instantiate(PlanePrefab);
		g.GetComponent<Plane>().SetValues(gameObject,ConnectedToAir[countryToGo].gameObject ,isInfected);
	}
	public void WaterDispersion(bool isInfected){
		int countryToGo = Random.Range(0,ConnectedToWater.Length);

	}
	[ContextMenu("Add InfectionCore")]
	public void AddInfectedPerson(){
		infected += 1f;
		ACores.Add(new AfflictionCore());
		started = true;
		Debug.Log("Core Added");
	}

}
