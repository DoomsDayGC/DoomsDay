using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    //static public bool isAlive = true;
    static public bool starHit = false; 
    
    private void OnCollisionEnter(Collision col)
    {
        PlayerStatus.isAlive = false;
    }
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.transform.name == "Player")
        {
            starHit = true;
        }
    }
}
