using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {
	public int damageToGive;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.name == "Player"){
			HealthManager.HurtPlayer (damageToGive);
			c.GetComponent<AudioSource> ().Play ();
			var player = c.GetComponent<PlayerController> ();
			player.knockBackCount = player.knockBackLength;
			if(c.transform.position.x < transform.position.x){
				player.knockFromRight = true;
			}
			else{
				player.knockFromRight = false; 
			}

		}
	}
}
