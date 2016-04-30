using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(Country))]
public class CountryEditor : Editor {

	public override void OnInspectorGUI(){
		Country Target = (Country)target;
		DrawDefaultInspector();
		if(Target.ACores != null){
			if(Target.ACores.Count > 0){
				foreach(AfflictionCore ac in Target.ACores){
					EditorGUILayout.LabelField(ac.PopulationDispersionInfected.ToString(), ac.AfflictionDispersionInfected.ToString());
				}	
			}	
		}


	}

}
