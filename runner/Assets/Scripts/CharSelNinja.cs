using UnityEngine;
using System.Collections;

public class CharSelNinja : MonoBehaviour {

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
		CharSelText.text = 1;
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
