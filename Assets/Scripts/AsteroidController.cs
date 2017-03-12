using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject player;
    public float meteorSpeed;

    Rigidbody rb;
    Vector3 direction;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= player.transform.position.x)
            direction = (player.transform.position - new Vector3(0, 0, 0)) - this.transform.position;
        else
            direction = (player.transform.position + new Vector3(0, 0, 0)) - this.transform.position;

        //if (direction.x >= 3 && (direction.y >= 0.3 || direction.y <= -0.3) && (direction.z >= 3 || direction.z <= -3))
        if(direction.z <= -2)
        {
            this.transform.rotation = Quaternion.LookRotation(direction);
        }
        transform.position += transform.forward * Time.deltaTime * meteorSpeed;
    }
}