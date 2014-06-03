﻿using UnityEngine;
using System.Collections;

public class PirateController : MonoBehaviour {
	public float maxSpeed = 10f;
	bool facingRight = true;
	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 275f;

	bool landed = true;
	bool idleAnim = false;
	bool doubleJump = false;

	float timer = 5f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
	
		if (grounded && !landed) {
			anim.SetTrigger("Landed");
			landed = true;
		}

		if (!grounded)
			landed = false;


		anim.SetBool ("Ground", grounded);


		if (grounded)
			doubleJump = false;

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip();

		if (rigidbody2D.velocity.x > 0 || rigidbody2D.velocity.y > 0) {
			timer = 5f;
			idleAnim = false;
		}
		else {
			timer -= Time.deltaTime;
		}
		
		if (timer <= 0)
			idleAnim = true;

		anim.SetBool("IdleAnim", idleAnim);
	}

	void Update() {
		if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space)) {
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));

			if (!doubleJump && !grounded)
				doubleJump = true;
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
