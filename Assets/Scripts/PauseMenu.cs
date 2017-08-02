using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public string levelSelect;
	public string mainMenu;
	public bool isPaused;
	public GameObject pauseMenuCanvas;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			//isPaused = !isPaused;
			PauseUnPause ();
		}
		if(isPaused){
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		}else{
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

	}

	public void PauseUnPause(){
		isPaused = !isPaused;
	}
	public void Resume(){
		isPaused = false;
	}

	public void LevelSelect(){
		//Time.timeScale = 1f;
		//isPaused = false;
		Application.LoadLevel (levelSelect);
	}

	public void QuitToMenu(){
		//isPaused = false;
		print ("In Quit: "+ isPaused);
		//Application.LoadLevel (mainMenu);
		SceneManager.LoadScene (mainMenu);
	}
}
