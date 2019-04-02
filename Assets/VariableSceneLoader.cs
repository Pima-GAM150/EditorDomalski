using System.Collections;
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
		suffering = new List<string>();

		for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++){

			//Debug.Log(SceneUtility.GetScenePathByBuildIndex(i));

			pain.Add(SceneUtility.GetScenePathByBuildIndex(i));
			suffering.Add(SceneManager.GetSceneByPath(pain[i]).name);

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