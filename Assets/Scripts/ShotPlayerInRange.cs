using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayerInRange : MonoBehaviour {
	public float playerRange;
	public GameObject enemyStar;
	public PlayerController thePlayer;
	public Transform lauchPoint;
	public float waitBetweenShots;
	private float shotCounter;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		shotCounter = waitBetweenShots;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3 (transform.position.x + playerRange, transform.position.y, transform.position.z));
		shotCounter -= Time.deltaTime;
		if(transform.localScale.x < 0 && thePlayer.transform.position.x > transform.position.x && thePlayer.transform.position.x < transform.position.x + playerRange && shotCounter < 0){
			Instantiate (enemyStar, lauchPoint.position, lauchPoint.rotation);
			shotCounter = waitBetweenShots;
		}
		if(transform.localScale.x > 0 && thePlayer.transform.position.x < transform.position.x && thePlayer.transform.position.x > transform.position.x - playerRange && shotCounter < 0){
			Instantiate (enemyStar, lauchPoint.position, lauchPoint.rotation);
			shotCounter = waitBetweenShots;
		}
	}
}
