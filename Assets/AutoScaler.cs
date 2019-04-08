using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AutoScaler : EditorWindow{

	static Vector3 scaleSet;
	static bool setx, sety, setz, scalex, scaley, scalez;

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

		sety = EditorGUILayout.Toggle("Set Y scale", sety);
		if(sety){

			scaleSet.Set(scaleSet.x, EditorGUILayout.FloatField("size in Y direction", scaleSet.y), scaleSet.z);

		}

		setz = EditorGUILayout.Toggle("Set Z scale", setz);
		if(setz){

			scaleSet.Set(scaleSet.x, scaleSet.y, EditorGUILayout.FloatField("size in Z direction", scaleSet.z));

		}

		if(!(setx && sety && setz)){

			if((setx && sety) || (sety && setz) || (setx && setz)){
				
				EditorGUILayout.LabelField("What should the unset direction be scaled to?(choose one)");
				if(setx)
					scalex = EditorGUILayout.Toggle("X", scalex);
				else
					scalex = false;

				if(sety)
					scaley = EditorGUILayout.Toggle("Y", scaley);
				else
					scaley = false;

				if(setz)
					scalez = EditorGUILayout.Toggle("Z", scalez);
				else
					scalez = false;

				if(((!scalex && !scaley) || (!scalex && !scalez) || (!scaley && !scalez)) && (scalex || scaley || scalez)){


				}

			}else{



			}

		}
	}

}
