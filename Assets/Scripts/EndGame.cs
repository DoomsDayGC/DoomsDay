using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject player;

    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        var distance = this.transform.position - playerRb.transform.position;

        this.transform.position = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, this.transform.position.z);

        if (distance.magnitude <= 8 && this.transform.position.z >= playerRb.transform.position.z)
        {
            PlayerStatus.cameraFollow = false;
            Controller.ignoreKey = true;
        }
        if (distance.magnitude >= 0 && this.transform.position.z <= playerRb.transform.position.z)
        {
            PlayerStatus.atTheEnd = true;
        }
    }
}
