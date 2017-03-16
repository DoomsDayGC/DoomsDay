using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour {

    public Rigidbody rb;
    public GameObject earth;

    // Use this for initialization
    private float distance;

    void Start ()
    {
        distance = transform.position.z - earth.transform.position.z;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = earth.transform.position + new Vector3(-earth.transform.position.x , -earth.transform.position.y ,distance);
	}
}
