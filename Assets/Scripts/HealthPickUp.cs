using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {
	public int healthToGive;
	public AudioSource pickUpSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.GetComponent<PlayerController>() == null){
			return;
		}
		HealthManager.HurtPlayer (-healthToGive);
		pickUpSound.Play ();
		Destroy (gameObject);
	}
}
