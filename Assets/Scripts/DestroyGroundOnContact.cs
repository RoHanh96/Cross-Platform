using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGroundOnContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "Ground"){
			Destroy (c.gameObject);
		}
	}
}
