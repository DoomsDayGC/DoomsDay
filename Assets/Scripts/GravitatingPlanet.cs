using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitatingPlanet : MonoBehaviour
{
    public GameObject planetToGravitate;

    public float orbitSpeed;

    public bool xAxe;
    public bool yAxe;
    public bool zAxe;

    // Update is called once per frame
    void Update ()
    {
        if (PlayerStatus.isAlive)
        {
            transform.RotateAround(planetToGravitate.transform.position, new Vector3(xAxe ? 1 : 0, yAxe ? 1 : 0, zAxe ? 1 : 0), orbitSpeed * 0.02f);
        }
	}
}
