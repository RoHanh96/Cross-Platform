using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	private float moveVelocity;
	private Rigidbody2D myRigidbody2D;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask WhatIsGround;
	public bool grounded;

	public bool doubleJumped;

	public Transform firePoint;
	public GameObject ninjaStar;
	public float shotDelay;
	private float shotDelayCounter;

	private Animator anim;

	public float knockback;
	public float knockBackLength;
	public float knockBackCount;
	public bool knockFromRight;

	public bool onLadder;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;
	private TouchControls touchControl;
	//public Vector2 vector2;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRigidbody2D = GetComponent<Rigidbody2D> ();
		onLadder = false;
		gravityStore = myRigidbody2D.gravityScale;
		touchControl = GetComponent<TouchControls> ();
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, WhatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		if(grounded){
			doubleJumped = false;
		}
		anim.SetBool ("Grounded", grounded);

#if UNITY_STANDALONE
		//touchControl. = false;
		if(Input.GetButtonDown("Jump") && grounded){
			Jump ();
		}
		if(Input.GetButtonDown("Jump") && !doubleJumped && !grounded){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			Jump ();
			doubleJumped = true;
		}

		moveVelocity = 0f;
		/*if(Input.GetKey(KeyCode.RightArrow)){
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = moveSpeed;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = -moveSpeed;
		}*/
		//moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");
		Move (Input.GetAxisRaw ("Horizontal"));
#endif
		if(knockBackCount <= 0){
			myRigidbody2D.velocity = new Vector2 (moveVelocity, myRigidbody2D.velocity.y);
		}
		else{
			if(knockFromRight){
				myRigidbody2D.velocity = new Vector2 (-knockback, knockback);
			}
			if(!knockFromRight){
				myRigidbody2D.velocity = new Vector2 (knockback, knockback);
			}
			knockBackCount -= Time.deltaTime;
		}

		anim.SetFloat ("Speed", Mathf.Abs(myRigidbody2D.velocity.x));

		if(myRigidbody2D.velocity.x > 0){
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}
		else if(myRigidbody2D.velocity.x < 0){
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

#if UNITY_STANDALONE
		if(Input.GetButtonDown("Fire1")){
			FireStar ();
			shotDelayCounter = shotDelay;
		}
		if(Input.GetButtonDown("Fire1")){
			shotDelayCounter -= Time.deltaTime;
			if(shotDelayCounter <0){
				shotDelayCounter = shotDelay;
				//Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
				FireStar ();
			}
		}
		if(anim.GetBool("Sword")){
			//anim.SetBool ("Sword", false);
			ResetSword ();
		}
		if(Input.GetButtonDown("Fire2")){
			//anim.SetBool ("Sword", true);
			Sword ();
		}
#endif

		if(onLadder){
			myRigidbody2D.gravityScale = 0f;
			climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");
			myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, climbVelocity);
		}
		else{
			myRigidbody2D.gravityScale = gravityStore;
		}
	}

	public void Move(float moveInput){
		moveVelocity = moveSpeed * moveInput;
	}

	public void Jump(){
		//myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, jumpHeight);
		if(grounded){
			//Jump ();
			myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, jumpHeight);
		}
		if(!doubleJumped && !grounded){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			//Jump ();
			myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, jumpHeight);
			doubleJumped = true;
		}
	}


	public void FireStar(){
		Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
	}

	public void Sword(){
		anim.SetBool ("Sword", true);
	}

	public void ResetSword(){
		anim.SetBool ("Sword", false);
	}
	void OnCollisionEnter2D(Collision2D c){
		if(c.transform.tag == "Moving Platform"){
			transform.parent = c.transform; 
		}
	}

	void OnCollisionExit2D(Collision2D c){
		if(c.transform.tag == "Moving Platform"){
			transform.parent = null;
		}
	}
}
