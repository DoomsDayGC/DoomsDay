using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGravity : MonoBehaviour
{
    // The, uhm.. Earth
    public GameObject earth;

    // The strength of the gravitational pull
    public float gravitationalPull;

    // Used to calibrate planet's gravity
    public float powerPerFrame;

    // The radius where gravity start to roll
    public float maxRadius;

    // Checks if the player is attracted by a sun or not
    private bool sunAttraction = false;

    // Checks if the player got passed the sun
    private bool beyond2Souls = false;

    // Checks if the player is trying to escape the sun's gravity
    private bool runYouFool = false;

    Vector3 offset;
    Vector3 direction;

    // The positions of the star's center
    private float xC;
    private float yC;
    private float zC;

    float gravity = 0.0f;

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

        
        ///////
        if (earth.transform.position.z >= (this.transform.position.z + this.transform.localScale.z))
        {
            beyond2Souls = true;
        }
        
        ///////
        if (gravity >= 0 && sunAttraction && ((Input.GetKey(GameManager.GM.leftFP) && this.transform.position.x > earth.transform.position.x)
            || (Input.GetKey(GameManager.GM.rightFP) && this.transform.position.x < earth.transform.position.x)
            || (Input.GetKey(GameManager.GM.upwardFP) && this.transform.position.y < earth.transform.position.y)
            || (Input.GetKey(GameManager.GM.downwardFP) && this.transform.position.y > earth.transform.position.y)))
        {
            gravity -= powerPerFrame * Time.deltaTime;
            runYouFool = true;
        }

        if (gravity <= gravitationalPull && sunAttraction && !runYouFool)
        {
            gravity += powerPerFrame * Time.deltaTime;
        }

        //Debug.Log(gravity);
        
        //////
        if ((x + y + z) <= Mathf.Pow(maxRadius - this.transform.localScale.x, 2) && !beyond2Souls)
        {
            sunAttraction = true;
            earth.GetComponent<Rigidbody>().AddForce(-direction * gravity, ForceMode.Acceleration);
        }
        else
        {
            gravity = 0.0f;
            sunAttraction = false;
            beyond2Souls = false;
            if (PlayerStatus.isAlive)
            {
                if (PlayerStatus.heatAmount >= 0)
                {
                    PlayerStatus.heatAmount -= 0.5f * Time.deltaTime;
                }
                else
                {
                    PlayerStatus.isAlive = false;
                }
            }
        }

        runYouFool = false;

        /////
        if (sunAttraction)
        {
            if (distance.magnitude <= 25 && this.transform.position.z >= earth.GetComponent<Rigidbody>().transform.position.z)
            {
                PlayerStatus.warning = true;
                PlayerStatus.itsAGo = true;
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
            if (PlayerStatus.cameraFollow == false && distance.magnitude >= 0 && this.transform.position.z <= earth.GetComponent<Rigidbody>().transform.position.z)
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
