using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
    }

     public float fallDelay = 2.0f;

    void OnCollisionEnter(Collision collidedWithThis)
    {
        if (collidedWithThis.gameObject.name == "Sphere")
        {
            StartCoroutine(FallAfterDelay());
        }
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody>().isKinematic = false;
    }
}

	
