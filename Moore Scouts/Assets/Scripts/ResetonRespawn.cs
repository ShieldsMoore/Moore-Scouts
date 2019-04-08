using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetonRespawn : MonoBehaviour {

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 startLocalScale;

    private Rigidbody2D myRB;
    private Animator myanim;
    private FlyingEnemy fe;
    private EnemyPatrol ep;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startLocalScale = transform.localScale;

        if (GetComponent<Rigidbody2D>() != null)
        {
            myRB = GetComponent<Rigidbody2D>();
        }
		
        if (GetComponent<Animator>() != null)
        {
            myanim = GetComponent<Animator>();
        }

        if (GetComponent<FlyingEnemy>() !=null)
        {
            fe = GetComponent<FlyingEnemy>();
        }


        if (GetComponent<EnemyPatrol>() != null)
        {
            ep = GetComponent<EnemyPatrol>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetObject()
    {
        gameObject.SetActive(true);
        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = startLocalScale;

        if (myRB != null)
        {
            myRB.velocity = Vector3.zero;
        }

        if (myanim != null)
        {
            myanim.SetBool("Dead", false);
        }

        if (fe != null)
        {
            fe.playerTarget = false;
        }

        if(ep != null)
        {
            ep.playertarget = false;
            ep.currentTarget = ep.Point2.position;
        }
    }
}
