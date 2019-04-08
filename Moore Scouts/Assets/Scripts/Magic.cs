using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour {

    public AudioSource explodeSound;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {

            collision.GetComponent<Animator>().SetBool("Dead", true);
            explodeSound.Play();
            //Destroy(collision.gameObject);
        }
    }

}

