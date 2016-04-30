using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(Affliction))]
public class AfflictionEditor : Editor {
	public override void OnInspectorGUI(){
		Affliction Target = (Affliction)target;
		Target.AfflictionPowerProperty = EditorGUILayout.Slider("Affliction Power",Target.AfflictionPowerProperty,0f,1f);
		Target.LandDisperionProperty = EditorGUILayout.Slider("Land Dispersion",Target.LandDisperionProperty,0f,1f);
		Target.AirDisperionProperty = EditorGUILayout.Slider("Air Dispersion",Target.AirDisperionProperty,0f,1f);
		Target.WaterDisperionProperty = EditorGUILayout.Slider("Water Dispersion",Target.WaterDisperionProperty,0f,1f);
		Target.KillPowerProperty = EditorGUILayout.Slider("Kill Power",Target.KillPowerProperty,0f,1f);
		Target.ExtraCoreChanceProperty = EditorGUILayout.Slider("New Core Chance",Target.ExtraCoreChanceProperty,0f,1f);
		Target.Warm = EditorGUILayout.Toggle("Warm", Target.Warm);
		Target.Cold = EditorGUILayout.Toggle("Cold", Target.Cold);
		Target.Hot = EditorGUILayout.Toggle("Hot", Target.Hot);
		Target.Wet = EditorGUILayout.Toggle("Wet", Target.Wet);
		Target.Dry = EditorGUILayout.Toggle("Dry", Target.Dry);
		Target.Arid = EditorGUILayout.Toggle("Arid", Target.Arid);

		/*
		SerializedObject t = new SerializedObject(Target);
		SerializedProperty thevect = t.FindProperty("Talents");
		EditorGUILayout.PropertyField(thevect,true);	
		t.ApplyModifiedProperties();
		*/
	}

}
