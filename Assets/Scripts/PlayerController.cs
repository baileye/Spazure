using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    public float speed;
    public float tilt;
    public Boundary boundary;
    new Rigidbody rigidbody;
    public float turnSpeed;
    public float thrustSpeed;

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
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject bolt = PhotonNetwork.Instantiate("Bolt", shotSpawn.position, shotSpawn.rotation, 1);
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }



    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Rotate(0, moveHorizontal * turnSpeed, 0);

        float thrust = moveVertical * thrustSpeed;
        rigidbody.AddForce(transform.forward * thrust);

    }

}
