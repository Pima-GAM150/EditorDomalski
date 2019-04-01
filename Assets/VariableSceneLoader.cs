using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class VariableSceneLoader : EditorWindow {
	
	[MenuItem("Window/New Option")]
	static void Init(){
		
		VariableSceneLoader window = (VariableSceneLoader)EditorWindow.GetWindow(typeof(VariableSceneLoader));
		window.Show();

	}



	static void OnGUI(){

		for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++){

			if(GUILayout.Button("Scene " + i)){
				
				SceneManager.LoadScene(i);

			}

		}

	}

}