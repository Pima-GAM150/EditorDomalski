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

	static void SetScale(int easier){
		GameObject selected = Selection.activeGameObject;

		if (selected != null){
			Bounds target = selected.GetComponent<Renderer>().bounds;

			if(easier == 1){

				if(setx){

					float scalemod = scaleSet.x / target.size.x;
					selected.transform.localScale = new Vector3(selected.transform.localScale.x * scalemod, selected.transform.localScale.y * scalemod, selected.transform.localScale.z * scalemod);

				}
				else if (sety){

					float scalemod = scaleSet.y / target.size.y;
					selected.transform.localScale = new Vector3(selected.transform.localScale.x * scalemod, selected.transform.localScale.y * scalemod, selected.transform.localScale.z * scalemod);

				}
				else if (setz){

					float scalemod = scaleSet.z / target.size.z;
					selected.transform.localScale = new Vector3(selected.transform.localScale.x * scalemod, selected.transform.localScale.y * scalemod, selected.transform.localScale.z * scalemod);

				}


			} else if(easier == 2){


				if(scalex){

					float scalemodx = scaleSet.x / target.size.x;
					if(sety){
						float scalemody = scaleSet.y / target.size.y;

						selected.transform.localScale = new Vector3(selected.transform.localScale.x * scalemodx, selected.transform.localScale.y * scalemody, selected.transform.localScale.z * scalemodx);

					} else if (setz){
						float scalemodz = scaleSet.z / target.size.z;
						selected.transform.localScale = new Vector3(selected.transform.localScale.x * scalemodx, selected.transform.localScale.y * scalemodx, selected.transform.localScale.z * scalemodz);

					}


				} else if(scaley){

					float scalemody = scaleSet.y / target.size.y;
					if(setx){
						float scalemodx = scaleSet.x / target.size.x;

						selected.transform.localScale = new Vector3(selected.transform.localScale.x * scalemodx, selected.transform.localScale.y * scalemody, selected.transform.localScale.z * scalemody);

					} else if (setz){
						float scalemodz = scaleSet.z / target.size.z;
						selected.transform.localScale = new Vector3(selected.transform.localScale.y * scalemodx, selected.transform.localScale.y * scalemody, selected.transform.localScale.z * scalemodz);

					}

				} else if(scalez){

					float scalemodz = scaleSet.z / target.size.z;
					if(setx){
						float scalemodx = scaleSet.x / target.size.x;

						selected.transform.localScale = new Vector3(selected.transform.localScale.x * scalemodx, selected.transform.localScale.y * scalemodz, selected.transform.localScale.z * scalemodz);

					} else if (sety){
						float scalemody = scaleSet.y / target.size.y;
						selected.transform.localScale = new Vector3(selected.transform.localScale.y * scalemodz, selected.transform.localScale.y * scalemody, selected.transform.localScale.z * scalemodz);

					}

				}


			} else if(easier == 3){

				selected.transform.localScale = new Vector3(selected.transform.localScale.x * (scaleSet.x / target.size.x), selected.transform.localScale.y * (scaleSet.y / target.size.y), selected.transform.localScale.z * (scaleSet.z / target.size.z));

			}

		}

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
				
				EditorGUILayout.LabelField("Dominant scale");
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

					if(GUILayout.Button("Set Scale!")){

						SetScale(2);

					}

				} else{

					EditorGUILayout.LabelField("Choose one dominant");

				}

			}else if(setx || sety || setz){

				if(GUILayout.Button("Set Scale!")){

					SetScale(1);

				}

			}

		}else{

			if(GUILayout.Button("Set Scale!")){

				SetScale(3);

			}

		}
	}

}
