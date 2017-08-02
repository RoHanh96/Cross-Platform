﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour {
	public int damageToGive;
	public int bounceOnEnemy;
	private Rigidbody2D myRigidbody2D;
	// Use this for initialization
	void Start () {
		myRigidbody2D = transform.parent.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "Enemy"){
			c.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
			myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, bounceOnEnemy);
		}
	}
}
