using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class VariableSceneLoader : EditorWindow {

	static List<string> pain;
	
	[MenuItem("Window/Variable Scene Loader")]
	static void Init(){

		pain = new List<string>();

		for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++){

			Debug.Log(SceneUtility.GetScenePathByBuildIndex(i));
			pain.Add(SceneUtility.GetScenePathByBuildIndex(i));

		}

		VariableSceneLoader window = (VariableSceneLoader)EditorWindow.GetWindow(typeof(VariableSceneLoader));
		window.Show();

	}



	 void OnGUI(){

		//Debug.Log(SceneManager.sceneCountInBuildSettings);
		int temp = 0;
		for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++){

			if(GUILayout.Button("Scene " + (i+1))){
				
				EditorSceneManager.OpenScene(pain[temp]);

			}
			temp++;

		}

	}

}