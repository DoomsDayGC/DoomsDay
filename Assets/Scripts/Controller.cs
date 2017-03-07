using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(GameManager.GM.upwardFP))
        {
            transform.position += Vector3.up;
        }
        if(Input.GetKey(GameManager.GM.downwardFP))
        {
            transform.position += Vector3.down;
        }
        if (Input.GetKey(GameManager.GM.leftFP))
        {
            transform.position += Vector3.left;
        }
        if (Input.GetKey(GameManager.GM.rightFP))
        {
            transform.position += Vector3.right;
        }
    }
}
