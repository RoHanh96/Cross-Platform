using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour {
	public int pointsToAdd;
	public AudioSource coinSoundEffect;
	void OnTriggerEnter2D(Collider2D c){
		if(c.GetComponent<PlayerController>() == null){
			return;
		}
		coinSoundEffect.Play ();
		ScoreManager.AddPoints (pointsToAdd);
		Destroy (gameObject);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
