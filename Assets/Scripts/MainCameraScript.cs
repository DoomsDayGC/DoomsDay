using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {

    public GameObject player;

    Vector3 offset;
    Rigidbody playerRb;

	// Use this for initialization
	void Start () {
        offset = Vector3.zero;
        playerRb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        offset = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y + 0.50f, playerRb.transform.position.z - 3.2f);

        if (PlayerStatus.cameraFollow)
        {
            this.transform.position = offset;
        }
    }
}
