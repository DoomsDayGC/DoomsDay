using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCameraScript : MonoBehaviour {

    public GameObject player;

    Vector3 offset;
    Rigidbody playerRb;

	// Use this for initialization
	void Start ()
    {
        offset = Vector3.zero;
        playerRb = player.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerStatus.redWarning && (PlayerStatus.blueWarning || PlayerStatus.yellowWarning || PlayerStatus.orangeWarning))
        {
            GetComponent<GravityWarning>().FadeOutBlue();
            GetComponent<GravityWarning>().FadeOutYellow();
            GetComponent<GravityWarning>().FadeOutOrange();
            GetComponent<GravityWarning>().FadeInRed();
        }
        else
        {
            if (PlayerStatus.blueWarning)
            {
                GetComponent<GravityWarning>().FadeInBlue();
            }
            else
            {
                GetComponent<GravityWarning>().FadeOutBlue();
            }

            if (PlayerStatus.yellowWarning)
            {
                GetComponent<GravityWarning>().FadeOutBlue();
                GetComponent<GravityWarning>().FadeInYellow();
            }
            else
            {
                GetComponent<GravityWarning>().FadeOutYellow();
            }

            if (PlayerStatus.orangeWarning)
            {
                GetComponent<GravityWarning>().FadeOutBlue();
                GetComponent<GravityWarning>().FadeOutYellow();
                GetComponent<GravityWarning>().FadeInOrange();
            }
            else
            {
                GetComponent<GravityWarning>().FadeOutOrange();
            }

            if (PlayerStatus.redWarning)
            {
                GetComponent<GravityWarning>().FadeOutBlue();
                GetComponent<GravityWarning>().FadeOutOrange();
                GetComponent<GravityWarning>().FadeInRed();
            }
            else
            {
                GetComponent<GravityWarning>().FadeOutRed();
            }
        }

        /*
        var allRenderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in allRenderers)
        {
            for (int i = 0; i < r.sharedMaterials.Length; i++)
            {
                r.sharedMaterials[i].SetColor("_Color", new Color(1,1,1,0.5f));
            }
        }*/

        offset = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y + 0.50f, playerRb.transform.position.z - 3.2f);
        if (PlayerStatus.cameraFollow)
        {
            this.transform.position = offset;
        }

        
    }
}
