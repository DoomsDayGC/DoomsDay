using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            PlayerStatus.isAlive = false;
            PlayerStatus.killedBy = "Planet";
        }
    }
}
