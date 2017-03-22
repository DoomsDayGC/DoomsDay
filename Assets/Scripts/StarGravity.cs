using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGravity : MonoBehaviour
{
    // The, uhm.. Earth
    public GameObject earth;

    // The strength of the gravitational pull
    public float gravitationalPull;

    // The radius where gravity start to roll
    public float maxRadius;

    // Checks if the player is attracted by a sun or not
    public static bool sunAttraction = false;

    Vector3 offset;
    Vector3 direction;

    // The positions of the star's center
    private float xC;
    private float yC;
    private float zC;

    private void Start()
    {
        offset = Vector3.zero;
        direction = Vector3.zero;

        xC = this.transform.position.x;
        yC = this.transform.position.y;
        zC = this.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        var distance = this.transform.position - earth.GetComponent<Rigidbody>().transform.position;
        offset = earth.transform.position - this.transform.position;


        direction = offset;
        direction.z = 0;

        var x = Mathf.Pow((earth.transform.position.x - xC), 2);
        var y = Mathf.Pow((earth.transform.position.y - yC), 2);
        var z = Mathf.Pow((earth.transform.position.z - zC), 2);

        if ((x + y + z) <= Mathf.Pow(maxRadius, 2))
        {
            sunAttraction = true;
            earth.GetComponent<Rigidbody>().AddForce(-direction * gravitationalPull, ForceMode.Acceleration);
        }
        else
        {
            sunAttraction = false;
        }


        if (sunAttraction)
        {
            if (distance.magnitude <= 25 && this.transform.position.z >= earth.GetComponent<Rigidbody>().transform.position.z)
            {
                PlayerStatus.warning = true;
            }
            else
            {
                PlayerStatus.warning = false;
            }
            if (distance.magnitude <= 8 && this.transform.position.z >= earth.GetComponent<Rigidbody>().transform.position.z)
            {
                PlayerStatus.cameraFollow = false;
                Controller.ignoreKey = true;
            }
            if (PlayerStatus.cameraFollow == false && distance.magnitude >= 5 && this.transform.position.z <= earth.GetComponent<Rigidbody>().transform.position.z)
            {
                PlayerStatus.isAlive = false;
            }
            if (PlayerStatus.heatAmount <= 100)
            {
                PlayerStatus.heatAmount += 3 * Time.deltaTime;
            }
        }
        
	}
}
