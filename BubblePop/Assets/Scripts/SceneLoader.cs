using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneLoader : MonoBehaviour {

    

	public void LoadNextScene()
	{

		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex+1);
	}

	public void OnpressQuit()
	{
		Application.Quit();
	}
	public void LoadStartScene()
	{
        FindObjectOfType<GameStatus>().resetSession();
        SceneManager.LoadScene(0);
	}

}
