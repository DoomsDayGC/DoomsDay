using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    public Rigidbody rb;
    public float thrust;
    public float maxSpeed;

    private float stopThrust;

    bool goesUpward = false;
    bool goesDownward = false;
    bool goesRight = false;
    bool goesLeft = false;
    float upSpeed, downSpeed, leftSpeed, rightSpeed;

    bool brakeY = false;
    bool brakeX = false;
    float friction = 0.95f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        upSpeed = (Vector3.up * maxSpeed).y;
        downSpeed = (Vector3.down * maxSpeed).y;
        leftSpeed = (Vector3.left * maxSpeed).x;
        rightSpeed = (Vector3.right * maxSpeed).x;
        stopThrust = thrust * 4;
    }

    private void Update()
    {
        if (rb.velocity.z < 10)
            rb.AddForce(Vector3.forward * thrust, ForceMode.Acceleration);

        if (Input.GetKey(GameManager.GM.upwardFP))
        {
            brakeY = false;
            if (goesDownward == false)
            {
                if (rb.velocity.y < upSpeed)
                {
                    // For using ForceMode.Force we need the palyer to have a Mass of roughly 0.16  
                    rb.AddForce(Vector3.up * thrust, ForceMode.Acceleration);
                    Debug.Log(Vector3.up * thrust + "-" + rb.velocity.y + "-" + upSpeed);
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

        if (!Input.GetKey(GameManager.GM.upwardFP))
        {
            brakeY = true;
        }

        if (Input.GetKey(GameManager.GM.downwardFP))
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

        if (Input.GetKey(GameManager.GM.leftFP))
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

        if (!Input.GetKey(GameManager.GM.leftFP))
        {
            brakeX = true;
        }

        if (Input.GetKey(GameManager.GM.rightFP))
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
            SceneManager.LoadScene(0);
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
