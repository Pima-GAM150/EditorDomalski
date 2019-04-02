using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class VariableSceneLoader : EditorWindow {
	
	[MenuItem("Window/Variable Scene Loader")]
	static void Init(){
		
		VariableSceneLoader window = (VariableSceneLoader)EditorWindow.GetWindow(typeof(VariableSceneLoader));
		window.Show();

	}



	 void OnGUI(){

		//Debug.Log(SceneManager.sceneCountInBuildSettings);

		for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++){

			if(GUILayout.Button("Scene " + i)){
				
				SceneManager.LoadScene(i);

			}

		}

	}

}