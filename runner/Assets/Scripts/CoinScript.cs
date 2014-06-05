using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	bool collected = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (collected && !audio.isPlaying)
			Destroy (gameObject);
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player" && !collected)
		{
			PlayerController.score++;
			audio.Play ();
			collected = true;
			gameObject.renderer.enabled = false;
		}
	}
}
