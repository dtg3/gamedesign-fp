using UnityEngine;
using System.Collections;

public class ClickAnimator : MonoBehaviour {

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
	}
	
	void OnMouseExit () 
	{
		over = false;
	}

	void OnMouseDown () {
		if (this.gameObject.tag == "Comic1") {
			//Application.LoadLevel ("");
		}
		
		if (this.gameObject.tag == "Title") {
			//Application.LoadLevel ("");
		}
	}
}
