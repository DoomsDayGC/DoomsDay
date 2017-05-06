using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject player;
    public float meteorSpeed;
    public bool aliveMeteor = true;
    //public float distanceToAccelerate;

    private Vector3 startPos;
    Vector3 direction;

    private void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerStatus.isAlive)
        {
            aliveMeteor = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

        direction = player.transform.position - this.transform.position;
        //Debug.Log(direction.magnitude + " " + direction.z);
        
        if (direction.z <= -2 && aliveMeteor)
        {
            this.transform.rotation = Quaternion.LookRotation(direction);
            //transform.position += transform.forward * 0.02f * 40;
        }
        
        if (direction.magnitude <= 300 && aliveMeteor)
            transform.position += transform.forward * 0.02f * 30;
        else
            transform.position += transform.forward * 0.02f * 1;
        
        if(!PlayerStatus.isAlive)
        {
            this.transform.position = startPos;
            aliveMeteor = true;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            aliveMeteor = false;
            this.transform.position = new Vector3(0, 0, -100);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}