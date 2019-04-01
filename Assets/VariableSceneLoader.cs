using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class VariableSceneLoader : EditorWindow {
	 

	void OnGUI(){

		for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++){

			if(GUI.Button(new Rect(20,40 + (i * 30),80,20), "Scene " + i))
			{
				SceneManager.LoadScene(i);
			}

		}

	}

}