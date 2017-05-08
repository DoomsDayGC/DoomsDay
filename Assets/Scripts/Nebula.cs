using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nebula : MonoBehaviour {

    public bool unfroze = true;
    public Camera camera;
    public GameObject player;
    //public bool Chase;
    private float chaseTime = 3f;

    private bool canMove = false;
    private Vector3 initialPoz;

	// Use this for initialization
	void Start () {
        initialPoz = this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if((int)chaseTime >= 0 && unfroze)
        {
            if(player.transform.position.z >= this.transform.position.z)
            {
                chaseTime -= 0.02f;
                canMove = true;
            }
        }
        
        if(canMove)
        {
            this.transform.position = new Vector3(initialPoz.x, initialPoz.y, player.transform.position.z);
        }

        if(!PlayerStatus.isAlive)
        {
            this.transform.position = initialPoz;
            unfroze = true;
            chaseTime = 3f;
            canMove = false;
        }

        if((int)chaseTime <=0)
        {
            canMove = false;
            unfroze = false;
        }

	}
}
