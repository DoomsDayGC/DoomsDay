using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGravity : MonoBehaviour {

    public GameObject player;

    public static bool cameraFollow = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var distance = this.transform.position - player.GetComponent<Rigidbody>().transform.position;

        if(Gravity.sunAttraction)
        {
            if (distance.magnitude <= 8 && this.transform.position.z >= player.GetComponent<Rigidbody>().transform.position.z)
                cameraFollow = false;
            if (cameraFollow == false && distance.magnitude >=5 && this.transform.position.z <= player.GetComponent<Rigidbody>().transform.position.z)
                PlayerStatus.isAlive = false;
        }
        
	}
}
