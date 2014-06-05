using UnityEngine;
using System.Collections;

public class Ducky : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			//audio.PlayOneShot();
		}
	}
}
