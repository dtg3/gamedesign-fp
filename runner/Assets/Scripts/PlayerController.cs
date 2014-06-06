using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float maxSpeed = 10f;
	bool facingRight = true;
	Animator anim;
	
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 275f;
	
	bool landed = true;
	bool idleAnim = false;
	bool doubleJump = false;
	
	public static bool dead = false;
	
	float timer = 5f;

	public static bool isNinja = true;

	public AudioClip fail;
	public AudioClip win;
	public AudioClip idle;

	bool idlePlayed = false;
	public static bool finishPlayed = false;

	public static int score = 0;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate () {
		if (CharSel.selectedCharacter == 0)
			isNinja = true;
		else
			isNinja = false;

		if (!dead) 
		{
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
			
			if (grounded && !landed) {
				anim.SetTrigger ("Landed");
				landed = true;
			}
			
			if (!grounded)
				landed = false;
			
			
			anim.SetBool ("Ground", grounded);
			
			
			if (grounded)
				doubleJump = false;
			
			anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
			
			float move = Input.GetAxis ("Horizontal");
			anim.SetFloat ("Speed", Mathf.Abs (move));
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();
			
			if (rigidbody2D.velocity.x > 0 || rigidbody2D.velocity.y > 0) {
				timer = 5f;
				idleAnim = false;
				idlePlayed = false;
			} else {
				timer -= Time.deltaTime;
			}
			
			if (timer <= 0)
			{
				idleAnim = true;
				if(!idlePlayed)
				{
					audio.PlayOneShot(idle);
					idlePlayed = true;
				}
			}
			
			anim.SetBool ("IdleAnim", idleAnim);
			
			// Fall too far...you die...
			if (transform.rigidbody2D.velocity.y < -20)
				Debug.LogError ("You should be dead");
		}
		else
		{
			anim.SetTrigger("Dead");
		}
		
		
	}
	
	void Update() {
		if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space) && !dead) {
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			
			if (!doubleJump && !grounded)
				doubleJump = true;
		}
	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Spike" && !dead) 
		{
			dead = true;
			audio.PlayOneShot(fail);
		}

		if (other.gameObject.tag == "Finish" && !finishPlayed && score >= 5)
		{
			audio.PlayOneShot(win);
			finishPlayed = true;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Spike" && !dead)
		{
			dead = true;
			audio.PlayOneShot(fail);
		}
	}
}

