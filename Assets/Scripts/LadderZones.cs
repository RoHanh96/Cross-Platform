using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZones : MonoBehaviour {
	private PlayerController player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.name == "Player"){
			player.onLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D c){
		if(c.name == "Player"){
			player.onLadder = false;
		}
	}
}
