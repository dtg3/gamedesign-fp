using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour {
	
	public Transform target;
	public float damping = 0.3f;
	public float lookAheadFactor = 7f;
	public float lookAheadReturnSpeed = 5f;
	public float lookAheadMoveThreshold = 0.1f;
	public bool autorun = false;
	public float autoOffset = 5f;

	public AudioClip ninja;
	public AudioClip pirate;

	public AudioClip ninjaGo;
	public AudioClip pirateGo;
	bool startPlayed = false;

	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;
	
	// Use this for initialization
	void Start () {
		lastTargetPosition = target.position;
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;

	}
	
	// Update is called once per frame
	void Update () 
	{
		playMusic();
		if(autorun)
			transform.position = new Vector3(target.position.x + autoOffset, target.position.y, -10);
		else
			transform.position = directionalRunner();

		if (lookAheadPos.y - Screen.height / 2.0 > target.position.y)
						transform.position = new Vector3 (transform.position.x, target.position.y, -10f);
				else if (lookAheadPos.y + Screen.height / 2.0 < target.position.y)
						transform.position = new Vector3 (transform.position.x, target.position.y, -10f);
	}

	Vector3 directionalRunner() {
		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (target.position - lastTargetPosition).x;
		
		bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;
		
		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
		}

		
		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

		lastTargetPosition = target.position;

		return newPos;
	}

	void playMusic()
	{
		if(PlayerController.isNinja)
			audio.clip = ninja;

		if(!PlayerController.isNinja)
			audio.clip = pirate;

		if (!audio.isPlaying)
			audio.Play();
		if (!startPlayed)
		{
			if(PlayerController.isNinja)
				audio.PlayOneShot(ninjaGo);
			else
				audio.PlayOneShot(pirateGo);
			startPlayed = true;
		}
	}
}
