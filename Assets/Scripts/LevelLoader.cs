using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
	public bool playerInZone;
	public string levelToLoad;
	public string levelTag;
	// Use this for initialization
	void Start () {
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Vertical") > 0 && playerInZone){
			LoadLevel ();
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.name == "Player"){
			playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D c){
		if(c.name == "Player"){
			playerInZone = false;
		}
	}

	public void LoadLevel(){
		PlayerPrefs.SetInt (levelTag, 1);
		print (levelTag + "Unlock");
		Application.LoadLevel (levelToLoad);
	}
}
