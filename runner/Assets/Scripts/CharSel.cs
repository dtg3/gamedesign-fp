using UnityEngine;
using System.Collections;

public class CharSel : MonoBehaviour {

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
		if (this.gameObject.tag == "PirateSelect") {
			over = true;
			CharSelText.text = 2;
		}
		
		if (this.gameObject.tag == "NinjaSelect") {
			over = true;
			CharSelText.text = 1;
		}
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
