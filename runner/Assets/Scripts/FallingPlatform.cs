using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour 
{

    public float delay = 5.0f;
    
    // Use this for initialization
	void Start () 
    {
        transform.rigidbody2D.isKinematic = true;
	}

	void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")
            Invoke("Fall", delay);
	}

    void Fall()
    {
        transform.rigidbody2D.isKinematic = false;
    }
}
