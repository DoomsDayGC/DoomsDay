using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    Vector3 lastPos;
    Transform obj;

    public GameObject planet;
    Rigidbody rb;
    Vector3 direction;

    float lastCheckTime;
    Vector3 lastCheckPos;
    float xSeconds;
    float zMuch;

    bool changedPos;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        lastCheckTime = 0;
        xSeconds = 3.0f;
        zMuch = 1.0f;

        obj = planet.GetComponent<Rigidbody>().transform;
        lastPos = obj.position;

        changedPos = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        direction = planet.transform.position - this.transform.position;
        //Debug.Log("----- " + direction);

        if (direction.x >= 3 && direction.y >= 0.3 && (direction.z >= 3 || direction.z <= -3))
            this.transform.rotation = Quaternion.LookRotation(direction);
        transform.position += transform.forward * Time.deltaTime * 8;
        /*
        Vector3 offset = obj.position - lastPos;

        if(offset.x > 0.1 || offset.y > 0.1 || offset.x < -0.1 || offset.y < -0.1)
        {
            lastPos = obj.position;
            transform.position += transform.forward * Time.deltaTime * 8;
            changedPos = true;
        }
        else
        {
            if (changedPos == false)
            {
                this.transform.rotation = Quaternion.LookRotation(direction);
                transform.position += transform.forward * Time.deltaTime * 8;
            }
        }
        */
        //Log(lastPos + " // " + offset);
        /*

        transform.position += transform.forward * Time.deltaTime * 8;
        */
        /*
        if ((Time.time - lastCheckTime) > xSeconds)
        {
            if ((planet.transform.position - lastCheckPos).magnitude < zMuch)
            {
                //Debug.Log("da");
                transform.position += transform.forward * Time.deltaTime * 8;
            }
            else
            {
                this.transform.rotation = Quaternion.LookRotation(direction);
                transform.position += transform.forward * Time.deltaTime * 8;
            }
            lastCheckPos = planet.transform.position;
            lastCheckTime = Time.time;
        }
        Debug.Log((planet.transform.position - lastCheckPos).magnitude + " / " + (Time.time - lastCheckTime));
        */  
    }
}
