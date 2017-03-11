using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour {

    ParticleSystem.ShapeModule shapeModule;
    public Rigidbody rb;
    // Use this for initialization
    private float distance;

    public GameObject earth;
	void Start () {
        distance = transform.position.z - earth.transform.position.z;
        rb = GetComponent<Rigidbody>();
        //shapeModule = GetComponent<ParticleSystem>().shape;
    }
	
	// Update is called once per frame
	void Update () {
        //obj = transform.FindChild("Moving Stars");
        //transform.Translate(v * maxSpeed * Time.deltaTime);//obj.GetComponentInChildren<Transform>().transform);
        //rb.MovePosition(transform.position +  * Time.deltaTime);
        //transform.Translate(Vector3.forward * Time.deltaTime, Camera.main.transform);
        this.transform.position = earth.transform.position + new Vector3(-earth.transform.position.x , -earth.transform.position.y ,distance);
        //shapeModule.radius = 4000;
        Debug.Log(earth.transform.position.z + " - " + transform.position.z);
	}
}
