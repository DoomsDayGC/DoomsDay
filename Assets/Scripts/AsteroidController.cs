using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject player;
    public float meteorSpeed;

    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - this.transform.position;

        if (direction.z <= -2)
        {
            this.transform.rotation = Quaternion.LookRotation(direction);
        }
        if (direction.magnitude <= 100)
            transform.position += transform.forward * Time.deltaTime * meteorSpeed;
        else
            transform.position += transform.forward * Time.deltaTime * 1;

    }
}