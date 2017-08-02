using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour {
	public float speed;
	public PlayerController player;
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int pointsToKill;
	public int damageToGive;
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		if(player.transform.localScale.x < 0){
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D c){
		print (c.gameObject.name);
		if(c.tag == "Enemy"){
			//Instantiate (enemyDeathEffect, c.transform.position, c.transform.rotation);
			//ScoreManager.AddPoints (pointsToKill);
			//Destroy (c.gameObject);
			c.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		}
		if(c.tag == "Boss"){
			c.GetComponent<BossHealthManager> ().giveDamage (damageToGive);
		}
			Instantiate (impactEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		//Chua biet tai sao lai can Tag enemy
	}
}
