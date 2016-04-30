using UnityEngine;
using System.Collections;

public class Affliction : MonoBehaviour{

	public float AfflictionPowerProperty{
		get{
			return AfflictionPower;
		}
		set{
			AfflictionPower = value;
		}
	}
	public static float AfflictionPower;

	public float AirDisperionProperty{
		get{
			return AirDispersion;
		}
		set{
			AirDispersion = value;
		}
	}
	public static float AirDispersion;

	public float WaterDisperionProperty{
		get{
			return WaterDispersion;
		}
		set{
			WaterDispersion = value;
		}
	}
	public static float WaterDispersion;


	public float LandDisperionProperty{
		get{
			return LandDispersion;
		}
		set{
			LandDispersion = value;
		}
	}
	public static float LandDispersion;

	public float KillPowerProperty{
		get{
			return KillPower;
		}
		set{
			KillPower = value;
		}
	}
	public static float KillPower;

	public float ExtraCoreChanceProperty{
		get{
			return ExtraCoreChance;
		}
		set{
			ExtraCoreChance = value;
		}
	}
	public static float ExtraCoreChance;

	public bool Warm, Cold, Hot;
	public bool Wet, Dry, Arid;
}
public class AfflictionCore {

	public float LastAfflictionDispersion, LastPopulationDispersion, AfflictionDispersionGap = 1f, PopulationDispersionGap = 1f;
	public float PopulationDispersionInfected, AfflictionDispersionInfected;
	float PopulationInfected;

	public AfflictionCore(){
		LastAfflictionDispersion = 0f; 
		LastPopulationDispersion = 0f; 
		AfflictionDispersionGap = 1f;
		PopulationDispersionGap = 1f;
		PopulationDispersionInfected = 0f;
		AfflictionDispersionInfected = 0f;

	}
	public float PopulationDispersion(Country c){
		float delay = Random.Range(0f,3f);
		float chance = Random.Range(0f,1f);
		float humansToInfect = 0f;
		if( c.time - LastPopulationDispersion >= PopulationDispersionGap){
			if(chance < Affliction.AfflictionPower){
				if(PopulationDispersionInfected < 1f){
					humansToInfect = 1 + (PopulationDispersionInfected * c.PopulationDensity());
				}else{
					humansToInfect = PopulationDispersionInfected * c.PopulationDensity();
				}
				PopulationDispersionInfected += humansToInfect;	
			}
			LastPopulationDispersion = c.time;
			PopulationDispersionGap = delay;
		}	
		return humansToInfect;
	}
	public float AfflictionDispersion(Country c){
		float delay = Random.Range(0f,1f);
		float chance = Random.Range(0f,1f);
		float humansToInfect = 0f;
		if(c.time - LastAfflictionDispersion >= AfflictionDispersionGap){
			if(chance < Affliction.AfflictionPower){
				if(AfflictionDispersionInfected < 1f){
					humansToInfect = 1f + (AfflictionDispersionInfected * Affliction.AfflictionPower);
				}else{
					humansToInfect = AfflictionDispersionInfected * Affliction.AfflictionPower;
				}
				AfflictionDispersionInfected += humansToInfect;
			}	
			LastAfflictionDispersion = c.time;	
			AfflictionDispersionGap = delay;
		}
		return humansToInfect; 
	}
	public static bool ChanceOfNewCore(){
		float random = Random.Range(0f,1f);
		if(random < Affliction.ExtraCoreChance){
			return true;
		}else{
			return false;
		}

	}
}
