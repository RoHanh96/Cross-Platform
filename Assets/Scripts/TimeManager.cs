using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
	public float startingTime;
	private float countingTime;
	//public PlayerController thePlayer;
	//public GameObject gameOverScreen;
	private Text theText;
	private PauseMenu pauseMenu;
	private HealthManager healthManager;
	// Use this for initialization
	void Start () {
		countingTime = startingTime;
		theText = GetComponent<Text> ();
		healthManager = FindObjectOfType<HealthManager> ();
		pauseMenu = FindObjectOfType<PauseMenu> ();
		//thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(pauseMenu.isPaused){
			return;
		}
		countingTime -= Time.deltaTime;
		if(countingTime <=0 ){
			//gameOverScreen.SetActive (true);
			//thePlayer.gameObject.SetActive (false);
			countingTime = 0;
			healthManager.KillPlayer ();

		}
		theText.text = "" + Mathf.Round(countingTime);
	}

	public void ResetTime(){
		countingTime = startingTime;
	}
}
