using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour {

	public int MoveSpeed;
	public float JumpHeight;
	private bool DoubleJump;

//Player Grounded variables
	public Transform GroundCheck;
	public float GroundCheckRadius;
	public LayerMask WhatIsGround;
	private bool Grounded;

// move velocity
	private float MoveVelocity;

	// Use this for initialization
	void Start () {
	
	}
	

	void FixedUpdate () {
		Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
	}

	// Update is called once per frame
	void Update () {

		// This code makes the character jump
		if(Input.GetKeyDown (KeyCode.Space)&& Grounded){
			Jump();
		}

		// Double jump
		if(Grounded)	
			DoubleJump = false;

		if(Input.GetKeyDown (KeyCode.Space)&& !DoubleJump && !Grounded){
			Jump();
			DoubleJump = true;
		}
		//Non-Slide Player
		MoveVelocity = ;

		// This code makes the character move from side to side using the A&D keys
		if(Input.GetKey (KeyCode.D)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			MoveVelocity = MoveSpeed;
		}
		if(Input.GetKey (KeyCode.A)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			MoveVelocity = -MoveSpeed;
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2(MoveVelocity, GetComponent<Rigidbody2D>().velocity.y);

	}

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
	}
}
