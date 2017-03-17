using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public static bool sunAttraction = false;

    public GameObject earth;

    public float gravitationalPull;

    public float maxRadius;

    private bool isAttracted = false;
    private Vector3 offset;
    private Vector3 direction;

    private void Start()
    {
        offset = Vector3.zero;
        direction = Vector3.zero;

    }

    void FixedUpdate()
    {
        offset = earth.transform.position - this.transform.position;
        SetGravity();

        direction = offset;
        direction.z = 0;

        if (isAttracted && this.tag == "Star")
        {
            sunAttraction = true;
        }

        if(isAttracted)
        {          
            earth.GetComponent<Rigidbody>().AddForce(-direction * gravitationalPull, ForceMode.Acceleration);
        }
    }

    void SetGravity()
    {
        var behind = false;
        var front = false;

        if (offset.z <= 0 && offset.z >= -maxRadius)
        {
            behind = true;
            front = false;
        }
        else
        {
            if (offset.z >= 0 && offset.z <= maxRadius)
            {
                front = true;
                behind = false;
            }
        }
        if (offset.z > maxRadius || offset.z < -maxRadius)
        {
            front = false;
            behind = false;
        }
        var isInZRange = behind || front;

        // for case offset.x <= maxRadius && offset.y >= -maxRadius
        if (offset.x > maxRadius && offset.y >= -maxRadius)
        {
            isAttracted = false;
        }
        else
            if (offset.x <= maxRadius && offset.y < -maxRadius)
        {
            isAttracted = false;
        }
        else
                if (offset.x <= maxRadius && offset.y >= -maxRadius)
        {
            isAttracted = true;
        }

        // for case offset.x >= -maxRadius && offset.y >= -maxRadius
        if (offset.x < -maxRadius && offset.y >= -maxRadius)
        {
            isAttracted = false;
        }
        else
            if (offset.x >= -maxRadius && offset.y < -maxRadius)
        {
            isAttracted = false;
        }
        else
                if (offset.x >= -maxRadius && offset.y >= -maxRadius)
        {
            isAttracted = true;
        }

        //for case offset.x >= -maxRadius && offset.y <= maxRadius
        if (offset.x < -maxRadius && offset.y <= maxRadius)
        {
            isAttracted = false;
        }
        else
        if (offset.x >= -maxRadius && offset.y > maxRadius)
        {
            isAttracted = false;
        }
        else
        if (offset.x >= -maxRadius && offset.y <= maxRadius)
        {
            isAttracted = true;
        }

        //for case offset.x <= maxRadius && offset.y <= maxRadius
        if (offset.x > maxRadius && offset.y <= maxRadius)
        {
            isAttracted = false;
        }
        else
            if (offset.x <= maxRadius && offset.y > maxRadius)
        {
            isAttracted = false;
        }
        else
                if (offset.x <= maxRadius && offset.y <= maxRadius)
        {
            isAttracted = true;
        }

        if (offset.x <= -maxRadius && offset.y >= -maxRadius)
        {
            isAttracted = false;
        }

        if (!isInZRange)
            isAttracted = false;
    }
}