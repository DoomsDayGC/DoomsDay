using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private Rigidbody rb; // Player's Rigidbody
    public float thrust; // Used for acceleration
    public float maxSpeed; // The maximum speed the player can achieve by going in a direction
    public float forwardSpeed; // The speed the player is moving forward in the universe

    //  The maximum radius the player can go until leaving the area
    public float maxRadius;

    // We need the forward speed outside this class as well therefor i made it static
    public static float staticForwardSpeed;
   
    // Used to make the Main Menu appear upon pressing the pause key
    private GameObject canvasObject;

    // Used to decelerate the player upon changing direction
    private float stopThrust;

    bool goesUpward = false;
    bool goesDownward = false;
    bool goesRight = false;
    bool goesLeft = false;
    float upSpeed, downSpeed, leftSpeed, rightSpeed;

    // Checks if the player changed direction or not
    bool brakeY = false;
    bool brakeX = false;
    float friction = 0.95f;

    // Used to stop the player from exiting the game area
    bool canGoXLeft = true;
    bool canGoXRight = true;
    bool canGoYUp = true;
    bool canGoYDown = true;

    private void Start()
    {
        staticForwardSpeed = forwardSpeed;
        if (GameObject.Find("MainMenuCanvas"))
        {
            canvasObject = GameObject.Find("MainMenuCanvas");
            canvasObject.SetActive(false);
        }
        rb = GetComponent<Rigidbody>();
        upSpeed = (Vector3.up * maxSpeed).y;
        downSpeed = (Vector3.down * maxSpeed).y;
        leftSpeed = (Vector3.left * maxSpeed).x;
        rightSpeed = (Vector3.right * maxSpeed).x;
        stopThrust = thrust * 4;
    }

    void GoForward()
    {
        if (rb.velocity.z < forwardSpeed)
            rb.AddForce(Vector3.forward * thrust, ForceMode.Acceleration);
    }

    void CheckRadius()
    {
        if(this.transform.position.x >= maxRadius)
        {
            canGoXRight = false;
            canGoXLeft = true;
        }
        else
        {
            canGoXRight = true;
        }

        if(this.transform.position.x <= -maxRadius)
        {
            canGoXLeft = false;
            canGoXRight = true;
        }
        else
        {
            canGoXLeft = true;
        }

        if(this.transform.position.y >= maxRadius)
        {
            canGoYUp = false;
            canGoYDown = true;
        }
        else
        {
            canGoYUp = true;
        }

        if(this.transform.position.y <= -maxRadius)
        {
            canGoYDown = false;
            canGoYUp = true;
        }
        else
        {
            canGoYDown = true;
        }
    }

    private void Update()
    {
        GoForward();

        CheckRadius();

        if (Input.GetKey(GameManager.GM.upwardFP) && canGoYUp == true)
        {
            brakeY = false;
            if (goesDownward == false)
            {
                if (rb.velocity.y < upSpeed)
                {
                    rb.AddForce(Vector3.up * thrust, ForceMode.Acceleration);
                    goesUpward = true;
                    goesDownward = false;
                }
            }
            else
            {
                if (rb.velocity.y <= 0)
                {
                    rb.AddForce(Vector3.up * stopThrust, ForceMode.Acceleration);
                }
                else
                {
                    goesDownward = false;
                }
            }
        }
        else
        {
            if (Input.GetKey(GameManager.GM.upwardFP) && canGoYUp == false)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
        }

        if (!Input.GetKey(GameManager.GM.upwardFP))
        {
            brakeY = true;
        }
        
        if (Input.GetKey(GameManager.GM.downwardFP) && canGoYDown == true)
        {
            brakeY = false;
            if (goesUpward == false)
            {
                if (rb.velocity.y > downSpeed)
                {
                    rb.AddForce(Vector3.down * thrust, ForceMode.Acceleration);
                    goesDownward = true;
                }
            }
            else
            {
                if (rb.velocity.y >= 0)
                {
                    rb.AddForce(Vector3.down * stopThrust, ForceMode.Acceleration);
                }
                else
                {
                    goesUpward = false;
                }
            }
        }
        if (!Input.GetKey(GameManager.GM.downwardFP))
        {
            brakeY = true;
        }

        if (Input.GetKey(GameManager.GM.leftFP) && canGoXLeft == true)
        {
            brakeX = false;
            if (goesRight == false)
            {
                if (rb.velocity.x > leftSpeed)
                {
                    rb.AddForce(Vector3.left * thrust, ForceMode.Acceleration);
                    goesLeft = true;
                }
            }
            else
            {
                if (rb.velocity.x >= 0)
                {
                    rb.AddForce(Vector3.left * stopThrust, ForceMode.Acceleration);
                }
                else
                {
                    goesRight = false;
                }
            }
        }
        else
        {
            if (Input.GetKey(GameManager.GM.leftFP) && canGoXLeft == false)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }
        }

        if (!Input.GetKey(GameManager.GM.leftFP))
        {
            brakeX = true;
        }

        if (Input.GetKey(GameManager.GM.rightFP) && canGoXRight == true)
        {
            brakeX = false;
            if (goesLeft == false)
            {
                if (rb.velocity.x < rightSpeed)
                {
                    rb.AddForce(Vector3.right * thrust, ForceMode.Acceleration);
                    goesRight = true;
                    goesLeft = false;
                }
            }
            else
            {
                if (rb.velocity.x <= 0)
                {
                    rb.AddForce(Vector3.right * stopThrust, ForceMode.Acceleration);
                }
                else
                {
                    goesLeft = false;
                }
            }
        }

        if (!Input.GetKey(GameManager.GM.rightFP))
        {
            brakeX = true;
        }

        if(Input.GetKey(GameManager.GM.pause))
        {
            SceneManager.LoadScene(1);         
        }

        if (brakeY && !Input.GetKey(GameManager.GM.upwardFP))
        {
            var vel = rb.velocity;
            vel.y *= friction;
            rb.velocity = vel;
            rb.angularVelocity *= friction;
        }
        if (brakeX && !Input.GetKey(GameManager.GM.leftFP))
        {
            var vel = rb.velocity;
            vel.x *= friction;
            rb.velocity = vel;
            rb.angularVelocity *= friction;
        }
    }

    private void OnGUI()
    {
        GUI.BeginGroup(new Rect(0,0, 100, 100));
        GUI.Label(new Rect(0, 20, 200, 200), rb.velocity.ToString());
        GUI.Label(new Rect(0, 40, 200, 200), upSpeed.ToString());
        GUI.EndGroup();
    }
}
