using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    // Use this for initialization
    public float speed;
    new Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
