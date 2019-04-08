using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    private LevelManager theLM;
    public int healthToGive;

	// Use this for initialization
	void Start () {

        theLM = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            theLM.GiveHealth(healthToGive);
            gameObject.SetActive(false);
        }
    }
}
