using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject player;
    public float meteorSpeed;
    //public float distanceToAccelerate;

    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - this.transform.position;
        //Debug.Log(direction.magnitude + " " + direction.z);
        /*
        if (direction.z <= -2)
        {
            this.transform.rotation = Quaternion.LookRotation(direction);
        }*/
        if (direction.magnitude <= 100)
            transform.position += transform.forward * 0.02f * meteorSpeed;
        else
            transform.position += transform.forward * 0.02f * 1;

    }
}