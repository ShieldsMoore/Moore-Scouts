using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour {

    public LevelManager theLevelManager;
    public int damageToGive;
	// Use this for initialization
	void Start () {

        theLevelManager = FindObjectOfType<LevelManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            theLevelManager.Respawn();
        }
    }
}
