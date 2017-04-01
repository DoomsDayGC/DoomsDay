using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGravity : MonoBehaviour
{
    private int attractionTimes = 0;

    // Saves the star's name
    private string starName;

    // Used to save the dist to the nearest Black Hole
    public static Vector3 earthToStarDist;

    // The, uhm.. Earth
    public GameObject earth;

    // The strength of the gravitational pull
    public float gravitationalPull;

    // Used to calibrate planet's gravity
    public float powerPerFrame;

    // The radius where gravity start to roll
    public float maxRadius;

    // Checks if the player is attracted by a sun or not
    private bool starAttraction = false;

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
    void Update ()
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
            //if (this.tag == "Save Star")
            //{
                Checkpoint.savedPosition = Controller.initialPos + new Vector3(0, 0, (this.transform.position.z + this.transform.localScale.z) + 5);
            //}
        }
        ///////
        if (gravity >= 0 && starAttraction && ((Input.GetKey(GameManager.GM.leftFP) && this.transform.position.x > earth.transform.position.x)
            || (Input.GetKey(GameManager.GM.rightFP) && this.transform.position.x < earth.transform.position.x)
            || (Input.GetKey(GameManager.GM.upwardFP) && this.transform.position.y < earth.transform.position.y)
            || (Input.GetKey(GameManager.GM.downwardFP) && this.transform.position.y > earth.transform.position.y)))
        {
            gravity -= powerPerFrame * 0.02f;
            runYouFool = true;
        }

        if (gravity <= gravitationalPull && starAttraction && !runYouFool && !PlayerStatus.reviveProtection)
        {
            gravity += powerPerFrame * 0.02f;
        }

        
        //////
        if ((x + y + z) <= Mathf.Pow(maxRadius - this.transform.localScale.x, 2) && !beyond2Souls && !PlayerStatus.reviveProtection)
        {
            starAttraction = true;
            earth.GetComponent<Rigidbody>().AddForce(-direction * gravity, ForceMode.Acceleration);

            starName = this.name;
            attractionTimes = 1;
            Checkpoint.showChk = true;
        }
        else
        {
            if (this.name == starName && attractionTimes == 1)
            {
                PlayerStatus.yellowWarning = false;
                PlayerStatus.orangeWarning = false;
                attractionTimes = 0;
                Checkpoint.showChk = false;
            }

            gravity = 0.0f;
            starAttraction = false;
            beyond2Souls = false;

            if (PlayerStatus.isAlive)
            {
                if (PlayerStatus.heatAmount >= 0)
                {
                    PlayerStatus.heatAmount -= PlayerStatus.heatDamageStatic * Time.deltaTime;
                }
                else
                {
                    if ((PlayerStatus.heatAmount >= 0 && PlayerStatus.heatAmount < 1) || PlayerStatus.heatAmount < 0)
                        PlayerStatus.isAlive = false;
                    PlayerStatus.killedBy = "Heat";
                }
            }
        }

        runYouFool = false;

        if(this.tag == "Black Hole")
        {
            PlayerStatus.feelingOldYet = false;
            earthToStarDist = offset;
        }

        /////
        if (starAttraction)
        {
            PlayerStatus.yellowWarning = true;
            //PlayerStatus.starName = this.name;
            if (this.tag == "Black Hole")
            {
                PlayerStatus.feelingOldYet = true;
            }

            if (distance.magnitude <= 50 && this.transform.position.z >= earth.GetComponent<Rigidbody>().transform.position.z)
            {
                PlayerStatus.yellowWarning = false;
                PlayerStatus.orangeWarning = true;
            }
            else
            {
                PlayerStatus.orangeWarning = false;
            }

            if (distance.magnitude <= 25 && this.transform.position.z >= earth.GetComponent<Rigidbody>().transform.position.z)
            {
                PlayerStatus.redWarning = true;
                PlayerStatus.orangeWarning = false;
            }
            else
            {
                PlayerStatus.redWarning = false;
            }
            if (distance.magnitude <= 8 && this.transform.position.z >= earth.GetComponent<Rigidbody>().transform.position.z)
            {
                PlayerStatus.cameraFollow = false;
                Controller.ignoreKey = true;
            }
            if (PlayerStatus.cameraFollow == false && distance.magnitude >= 0 && this.transform.position.z <= earth.GetComponent<Rigidbody>().transform.position.z)
            {
                PlayerStatus.isAlive = false;
                PlayerStatus.killedBy = "Star";
            }
            if (!PlayerStatus.cameraFollow && PlayerStatus.isAlive)
            {
                earth.GetComponent<Rigidbody>().AddForce(-direction * 5, ForceMode.Acceleration);
            }
            if (PlayerStatus.isAlive)
            {
                /*
                if(this.tag == "Save Star")
                {

                }
                */
                if (this.tag == "Star")
                {
                    if (PlayerStatus.heatAmount <= 100)
                    {
                        PlayerStatus.heatAmount += PlayerStatus.heatGainStatic * Time.deltaTime; // 3
                    }
                }
                else
                {
                    if (PlayerStatus.isAlive)
                    {
                        if (PlayerStatus.heatAmount >= 0)
                        {
                            PlayerStatus.heatAmount -= PlayerStatus.heatDamageStatic * Time.deltaTime; // 0.5f
                        }
                        else
                        {
                            if ((PlayerStatus.heatAmount >= 0 && PlayerStatus.heatAmount < 1) || PlayerStatus.heatAmount < 0)
                                PlayerStatus.isAlive = false;
                            PlayerStatus.killedBy = "Heat";
                        }
                    }
                }
            }
        }
	}
}
