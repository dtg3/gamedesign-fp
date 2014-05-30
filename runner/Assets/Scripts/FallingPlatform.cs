using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.rigidbody2D.gravityScale = 0;
	}

	void OnCollisionEnter2D() {
		transform.rigidbody2D.gravityScale = 5f;
	}
}
