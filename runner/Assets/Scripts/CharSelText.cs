using UnityEngine;
using System.Collections;

public class CharSelText : MonoBehaviour {

	Animator anim;
	public static int text = 0;
	
	void Start() {
		anim = GetComponent<Animator>();
		text = 0;
	}
	void Update() {
		anim.SetInteger("Selected", text);
	}
}
