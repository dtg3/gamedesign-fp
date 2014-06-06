﻿using UnityEngine;
using System.Collections;

public class MouseTrapScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			other.rigidbody2D.fixedAngle = false;
			audio.Play();
			//Debug.Break();
		}
	}
}