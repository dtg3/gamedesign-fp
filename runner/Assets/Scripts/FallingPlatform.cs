﻿using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	bool trapActive = false;
	bool back = false;
	Vector3 startPos;

	// Use this for initialization
	void Start () {
		trapActive = false;
		back = false;
		startPos = transform.position;
	}

	void Update () {
		if (trapActive) {
			if (!back) {
				transform.Translate(Vector3.right * Time.deltaTime * 4f);
				if (transform.position.x > startPos.x + .2f)
					back = true;
			}
			else {
				transform.Translate(Vector3.left * Time.deltaTime * 4f);
				if (transform.position.x < startPos.x - .2f)
					back = false;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player")
			if (!trapActive) {
				trapActive = true;
				StartCoroutine(Fall());
			}
	}

	public IEnumerator Fall() {
		yield return new WaitForSeconds(.4f);
		trapActive = false;
		Rigidbody2D trap = this.gameObject.AddComponent<Rigidbody2D> (); //This introduces a runtime warning, but hasn't proven game breaking. Just ignore for now.
		trap.gravityScale = 5f;
	}
}
