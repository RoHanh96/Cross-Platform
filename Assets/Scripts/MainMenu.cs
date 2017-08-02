using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public string startLevel;
	public string levelSelect;
	public int playerLives;
	public int playerHealth;
	public string level1Tag;
	public string level2Tag;
	public string level3Tag;
	public void NewGame(){
		
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);
		PlayerPrefs.SetInt(level1Tag, 1);
		PlayerPrefs.SetInt(level2Tag, 0);
		PlayerPrefs.SetInt(level3Tag, 0);
		PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		Application.LoadLevel (startLevel);

	}

	public void LevelSelect(){
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);
		PlayerPrefs.SetInt (level1Tag, 1);
		PlayerPrefs.SetInt (level2Tag, 0);
		PlayerPrefs.SetInt (level3Tag, 0);
		if(!PlayerPrefs.HasKey("PlayerLevelSelectPosition")){
			PlayerPrefs.SetInt ("PlayerLevelSelectPosition", 0);
		}
		Application.LoadLevel (levelSelect);
	}

	public void QuitGame(){
		Debug.Log ("Game Exited!");
		Application.Quit ();
	}
}
