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
        this.transform.position = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y, this.transform.position.z);
	}
}
