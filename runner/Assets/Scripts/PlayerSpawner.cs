using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject[] characters;

	// Use this for initialization

	void Awake () {
		Instantiate (characters[CharSel.selectedCharacter], new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);	
	}
}
