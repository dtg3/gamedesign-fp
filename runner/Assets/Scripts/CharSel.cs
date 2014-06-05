using UnityEngine;
using System.Collections;

public class CharSel : MonoBehaviour {

	Animator anim;
	bool over = false;
	public static int selectedCharacter;
	
	void Start() {
		anim = GetComponent<Animator>();
		selectedCharacter = 0;
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
		if (this.gameObject.tag == "PirateSelect") {
			selectedCharacter = 1;
		}
		
		if (this.gameObject.tag == "NinjaSelect") {
			selectedCharacter = 0;
		}

		Application.LoadLevel ("Comic1");
	}
}
