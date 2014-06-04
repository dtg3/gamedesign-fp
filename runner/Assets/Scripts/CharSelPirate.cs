using UnityEngine;
using System.Collections;

public class CharSelPirate : MonoBehaviour {

	Animator anim;
	bool over = false;
	
	void Start() {
		anim = GetComponent<Animator>();
	}
	void Update() {
		anim.SetBool("Over", over);
	}
	
	void OnMouseEnter ()
	{
		over = true;
		CharSelText.text = 2;
	}
	
	void OnMouseExit () 
	{
		over = false;
		CharSelText.text = 0;
	}
	
	void OnMouseDown () {
		//Application.LoadLevel ("");
	}
}
