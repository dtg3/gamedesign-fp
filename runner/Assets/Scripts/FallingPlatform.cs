using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	bool trapActive = false;
	// Use this for initialization
	void Start () {
		trapActive = false;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player")
			if (!trapActive) {
				trapActive = true;
				StartCoroutine(Fall());
			}
	}

	public IEnumerator Fall() {
		yield return new WaitForSeconds(1f);
		Rigidbody2D trap = this.gameObject.AddComponent<Rigidbody2D> ();
		trap.gravityScale = 5f;
	}
}
