using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

    public Image key;
    public SpriteRenderer sr;
    public GameObject openDoor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sr.enabled = false;
            key.enabled = true;
            openDoor.SetActive(true);
        }
    }
}
