using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : MonoBehaviour {
	public AudioSource pickUpLifeSound;
	private LifeManager lifeSystem;
	// Use this for initialization
	void Start () {
		lifeSystem = FindObjectOfType<LifeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.name == "Player"){
			lifeSystem.GiveLife ();
			pickUpLifeSound.Play ();
			Destroy (gameObject);
		}
	}
}
