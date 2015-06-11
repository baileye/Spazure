﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }


    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

	
	// Update is called once per frame
	void Update () {
	
	}

    public float speed;
    public float tilt;
    public Boundary boundary;
    new Rigidbody rigidbody;


    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt * Mathf.Abs(rigidbody.position.x / 2f));


    }

}
