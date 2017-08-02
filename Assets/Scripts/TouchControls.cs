using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {
	private PlayerController thePlayer;
	private LevelLoader levelLoader;
	private PauseMenu pauseMenu;
	// Use this for initialization
	void Start () {
		levelLoader = FindObjectOfType<LevelLoader> ();
		thePlayer = FindObjectOfType<PlayerController> ();
		pauseMenu = FindObjectOfType<PauseMenu> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LeftArrow(){
		print ("left clicked");
		thePlayer.Move (-1);
	}

	public void RightArrow(){
		thePlayer.Move (1);
	}

	public void UnpressArrow(){
		thePlayer.Move (0);
	}

	public void Sword(){
		thePlayer.Sword ();
	}

	public void ResetSword(){
		thePlayer.ResetSword ();
	}

	public void Star(){
		thePlayer.FireStar ();
	}

	public void Jump(){
		thePlayer.Jump ();
		if(levelLoader.playerInZone){
			levelLoader.LoadLevel ();
		}
	}

	public void Pause(){
		pauseMenu.PauseUnPause ();
		//pauseMenu.isPaused = !pauseMenu.isPaused;
	}
}
