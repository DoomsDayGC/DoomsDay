using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject Earth;

    public float gravitationalPull;

    void FixedUpdate()
    {
        //apply spherical gravity to the planet
        if (Earth.GetComponent<Rigidbody>().velocity.z <= Controller.staticForwardSpeed)
            Earth.GetComponent<Rigidbody>().AddForce((this.transform.position - Earth.transform.position).normalized * gravitationalPull);
    }
}