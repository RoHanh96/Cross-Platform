using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public GameObject currentCheckPoint;
	private PlayerController playerController;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelay;
	public int pointPenaltyOnDeath;
	public HealthManager healthManager;
	private float gravityStore;
	private CameraController camera;
	// Use this for initialization
	void Start () {
		playerController = FindObjectOfType<PlayerController> ();
		camera = FindObjectOfType<CameraController> ();
		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer(){
		//Debug.Log ("Respawn Player");
		StartCoroutine ("RespawnPlayerCo");

	}

	public IEnumerator RespawnPlayerCo(){
		Instantiate (deathParticle, playerController.transform.position, playerController.transform.rotation);
		playerController.enabled = false;
		playerController.GetComponent<Renderer> ().enabled = false;
		//gravityStore = playerController.GetComponent<Rigidbody2D> ().gravityScale;
		//playerController.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		//playerController.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		camera.isFollowing = false;
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		yield return new WaitForSeconds (respawnDelay);
		//playerController.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		playerController.transform.position = currentCheckPoint.transform.position;
		playerController.enabled = true;
		playerController.knockBackCount = 0;
		playerController.GetComponent<Renderer> ().enabled = true;
		healthManager.FullHealth ();
		healthManager.isDead = false;
		camera.isFollowing = true; 
		Instantiate (respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
	}
}
