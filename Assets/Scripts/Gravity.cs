using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // The, uhm.. Earth
    public GameObject earth;

    // The strength of the gravitational pull
    public float gravitationalPull;
    
    // The radius where gravity start to roll
    public float maxRadius;

    // Checks whether the player is attracted or not
    private bool planetAttraction = false;

    private Vector3 offset;
    private Vector3 direction;

    // The positions of the planet's center
    private float xC;
    private float yC;
    private float zC;

    private void Start()
    {
        offset = Vector3.zero;
        direction = Vector3.zero;

        xC = this.transform.position.x;
        yC = this.transform.position.y;
        zC = this.transform.position.z;
    }

    void FixedUpdate()
    {
        offset = earth.transform.position - this.transform.position;
        //SetGravity();

        direction = offset;
        direction.z = 0;

        var x = Mathf.Pow((earth.transform.position.x - xC), 2);
        var y = Mathf.Pow((earth.transform.position.y - yC), 2);
        var z = Mathf.Pow((earth.transform.position.z - zC), 2);
        
        //if(isAttracted)
        if ((x + y + z) <= Mathf.Pow(maxRadius, 2))
        {
            planetAttraction = true;
            earth.GetComponent<Rigidbody>().AddForce(-direction * gravitationalPull, ForceMode.Acceleration);
        }
        else
        {
            planetAttraction = false;
        }

        if(planetAttraction)
        {
            if (offset.magnitude <= (3 / 4.0 * maxRadius) && this.transform.position.z >= earth.GetComponent<Rigidbody>().transform.position.z)
            {
                PlayerStatus.warning = true;
            }
            else
            {
                PlayerStatus.warning = false;
            }
            if (offset.magnitude <= (1 / 2.0 * maxRadius) && this.transform.position.z >= earth.GetComponent<Rigidbody>().transform.position.z)
            {
                PlayerStatus.cameraFollow = false;
                Controller.ignoreKey = true;
            }
        }
    }

    /*
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
    */
}