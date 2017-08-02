using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStarController : MonoBehaviour {

	public float speed;
	public PlayerController player;
	//public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	//public int pointsToKill;
	public int damageToGive;
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		if(player.transform.position.x < transform.position.x){
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
		//print (c.gameObject.name);
		if(c.name == "Player"){
			//Instantiate (enemyDeathEffect, c.transform.position, c.transform.rotation);
			//ScoreManager.AddPoints (pointsToKill);
			//Destroy (c.gameObject);
			//c.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
			//print ("111111");
			HealthManager.HurtPlayer (damageToGive);
		}
		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
		//Chua biet tai sao lai can Tag enemy
	}
}