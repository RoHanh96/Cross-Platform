using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectTouch : MonoBehaviour {
	public LevelSelectManager levelSelectManager;
	// Use this for initialization
	void Start () {
		levelSelectManager = FindObjectOfType<LevelSelectManager> ();
		levelSelectManager.touchMode = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void MoveLeft(){
		levelSelectManager.positionSelector -= 1;
		if(levelSelectManager.positionSelector < 0){
			levelSelectManager.positionSelector = 0;
		}
	}

	public void MoveRight(){
		levelSelectManager.positionSelector += 1;
		if(levelSelectManager.positionSelector >= levelSelectManager.levelTags.Length){
			levelSelectManager.positionSelector = levelSelectManager.levelTags.Length - 1;
		}
	}

	public void LoadLevel(){
		PlayerPrefs.SetInt ("PlayerLevelSelectPosition", levelSelectManager.positionSelector);
		Application.LoadLevel (levelSelectManager.levelName [levelSelectManager.positionSelector]);
	}
}
