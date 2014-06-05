using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject[] characters;

	// Use this for initialization
	void Start () {
		Instantiate (characters[CharSel.selectedCharacter]);
	}
}
