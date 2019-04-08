using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - 10f);
        transform.position = targetPosition;
	}
}
