using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    private GameObject earth;

    private void Start()
    {
        earth = GameObject.Find("Player");
    }

    private void OnCollisionEnter(Collision col)
    {
        //if((earth.transform.position - (Controller.maxRadiusStatic - this.transform.localScale.x) / 2 + 10)) > 10)
        if (col.transform.tag == "Player")
        {
            PlayerStatus.isAlive = false;
            PlayerStatus.killedBy = "Planet";
        }
    }
    
    private void OnParticleCollision(GameObject other)
    {
    }
}
