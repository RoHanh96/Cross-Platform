using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask WhatIsWall;
	public bool hittingWall;
	public Transform edgeCheck;
	public bool notAtEdge;
	private float xSize;
	void Start () {
		xSize = transform.localScale.y;
	}

	// Update is called once per frame
	void Update () {
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, WhatIsWall);
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, WhatIsWall);
		if(hittingWall || !notAtEdge){
			moveRight = !moveRight;
		}
		if(moveRight){
			transform.localScale = new Vector3 (-xSize, transform.localScale.y, transform.localScale.z);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
		else{
			transform.localScale = new Vector3 (xSize,transform.localScale.y, transform.localScale.z);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}
}
