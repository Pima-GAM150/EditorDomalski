using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AutoScaler : EditorWindow{

	[MenuItem("Window/Auto Scaler")]
	static void Init(){

		AutoScaler window = (AutoScaler)EditorWindow.GetWindow(typeof(AutoScaler));
		window.Show();

	}

   
	void OnGUI(){



	}

}
