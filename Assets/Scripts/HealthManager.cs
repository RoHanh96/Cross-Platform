using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	public int maxHealthPlayer;
	public static int healthPlayer;
	public bool isDead;
	private TimeManager theTime;
	public Slider healthBar;
	private LevelManager levelManager;
	private LifeManager lifeSystem;
	//Text text;
	// Use this for initialization
	void Start () {
		//text = GetComponent<Text> ();
		healthBar = GetComponent<Slider> ();
		healthPlayer = PlayerPrefs.GetInt("PlayerCurrentHealth");
		theTime = FindObjectOfType<TimeManager> ();
		levelManager = FindObjectOfType<LevelManager> ();
		lifeSystem = FindObjectOfType<LifeManager> ();
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(healthPlayer <= 0 && !isDead){
			healthPlayer = 0;
			lifeSystem.TakeLife ();
			//print ("roi xuong !");
			theTime.ResetTime ();	
			levelManager.RespawnPlayer ();
			//ScoreManager.Reset ();

			isDead = true;
		}
		if(healthPlayer > maxHealthPlayer){
			healthPlayer = maxHealthPlayer;
		}
		//text.text = "" + healthPlayer;	
		healthBar.value = healthPlayer;
	}

	public static void HurtPlayer(int damagaToGive){
		healthPlayer -= damagaToGive;
		PlayerPrefs.SetInt ("PlayerCurrentHealth", healthPlayer);
	}

	public void FullHealth(){
		healthPlayer = PlayerPrefs.GetInt("PlayerMaxHealth");
		PlayerPrefs.SetInt ("PlayerCurrentHealth", healthPlayer);
	}

	public void KillPlayer(){
		healthPlayer = 0;
	}
}
