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
            if(this.tag == "Black Hole")
            {
                PlayerStatus.cameraFollow = false;
                col.transform.position = this.transform.position - new Vector3(-30, transform.position.y, transform.position.z);
            }
        }
    }
}
