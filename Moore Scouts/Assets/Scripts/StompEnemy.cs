using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour {

    private Rigidbody2D playerRB;
    public float bounceForce;
    public AudioSource explodeSound;

	// Use this for initialization
	void Start () {
        playerRB = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, bounceForce);
            collision.GetComponent<Animator>().SetBool("Dead", true);
            explodeSound.Play();
            //Destroy(collision.gameObject);
        }
    }
}
