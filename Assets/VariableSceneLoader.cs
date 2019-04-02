﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class VariableSceneLoader : EditorWindow {

	static List<string> pain;
	static List<string> suffering;
	
	[MenuItem("Window/Variable Scene Loader")]
	static void Init(){

		PainInit();

		VariableSceneLoader window = (VariableSceneLoader)EditorWindow.GetWindow(typeof(VariableSceneLoader));
		window.Show();

	}

	static void PainInit(){

		pain = new List<string>();

		for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++){

			//Debug.Log(SceneUtility.GetScenePathByBuildIndex(i));

			pain.Add(SceneUtility.GetScenePathByBuildIndex(i));

		}

		SufferingAppend();

	}

	static void SufferingAppend(){

		suffering = new List<string>();

		for(int i = 0; i < pain.Count; i++){

			string temp = pain[i];
			Debug.Log(temp);
			temp = temp.Remove(0, temp.IndexOf('/') + 1);
			bool tempb = true;
			Debug.Log(temp);
			int safety = 0;
			while(tempb){

				if(temp.IndexOf('/') == -1){
				
					tempb = false;
				
				}else{

					temp = temp.Remove(0, temp.IndexOf('/') + 1);
					Debug.Log(temp);

				}

				if(safety > 100){

					break;

				}
				safety++;
			}

			temp = temp.Remove(temp.IndexOf('.'));
			Debug.Log(temp);
			suffering.Add(temp);

		}

	}


	 void OnGUI(){

		//Debug.Log(SceneManager.sceneCountInBuildSettings);
		int temp = 0;
		bool save = EditorGUILayout.Toggle("Save before loading", true);
		if(pain == null || pain.Count < SceneManager.sceneCountInBuildSettings || pain.Count > SceneManager.sceneCountInBuildSettings){ PainInit(); }

		for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++){

			if(GUILayout.Button(suffering[i])){

				if(save){

					EditorSceneManager.MarkAllScenesDirty();
					EditorSceneManager.SaveOpenScenes();

				}

				EditorSceneManager.OpenScene(pain[temp]);

			}
			temp++;

		}

	}

}