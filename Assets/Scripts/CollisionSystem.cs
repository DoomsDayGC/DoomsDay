using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    static public bool isAlive = true;
    static public bool starHit = false;
    
    private void OnCollisionEnter(Collision col)
    {
        isAlive = false;
    }
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.transform.name == "Player")
        {
            starHit = true;
        }
    }

    private void OnGUI()
    {
        GUI.BeginGroup(new Rect(0, 0, 100, 100));
        GUI.Label(new Rect(0, 60, 100, 100), isAlive.ToString());
        GUI.EndGroup();
    }
}
