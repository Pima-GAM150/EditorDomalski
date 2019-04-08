using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AutoScaler : EditorWindow{

	static Vector3 scaleSet;
	static bool setx, sety, setz;

	[MenuItem("Window/Auto Scaler")]
	static void Init(){

		scaleSet = new Vector3();
		AutoScaler window = (AutoScaler)EditorWindow.GetWindow(typeof(AutoScaler));
		window.Show();

	}

	static void SetScale(){



	}

   
	void OnGUI(){

		setx = EditorGUILayout.Toggle("Set X scale", setx);
		if(setx){

			scaleSet.Set(EditorGUILayout.FloatField("size in X direction", scaleSet.x), scaleSet.y, scaleSet.z);

		}

	}

}
