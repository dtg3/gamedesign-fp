using UnityEngine;
using System.Collections;

public class FinishScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player" && PlayerController.score >= 5)
		{
			gameObject.tag = "Untagged";
		}
		else
		{
			gameObject.tag = "Spike";
		}
	}
}
