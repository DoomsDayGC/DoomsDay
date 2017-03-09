using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Rigidbody rb;
    public float thrust;
    public float maxSpeed;

    bool goesUpward = false;
    bool goesDownward = false;
    bool goesRight = false;
    bool goesLeft = false;
    float upSpeed, downSpeed, leftSpeed, rightSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GoesForward();
        GoesDownward();
        leftSpeed = (Vector3.left * thrust *2).x;
        // Way more testing
        rightSpeed = (Vector3.right * thrust *8).x;
        // Some more
    }

    private void GoesForward()
    {
        upSpeed = (Vector3.up * maxSpeed).y;
    }

    private void GoesDownward()
    {
        downSpeed = (Vector3.down * maxSpeed).y;
    }


    void Update ()
    {

        if (Input.GetKey(GameManager.GM.upwardFP))
        {
            if (!goesDownward)
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
                    rb.AddForce(Vector3.up * thrust * 7, ForceMode.Acceleration);
                }
                else
                {
                    goesDownward = false;
                }
            }

        }
        if(Input.GetKey(GameManager.GM.downwardFP))
        { 
            if (!goesUpward)
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
                    rb.AddForce(Vector3.down * thrust * 7, ForceMode.Acceleration);
                }
                else
                {
                    goesUpward = false;
                }
            }
                
        }
        if (Input.GetKey(GameManager.GM.leftFP))
        {
            if (!goesRight)
            {
                if (rb.velocity.x > downSpeed)
                {
                    rb.AddForce(Vector3.left * thrust, ForceMode.Acceleration);
                    goesLeft = true;
                }
            }
            else
            {
                if (rb.velocity.x >= 0)
                {
                    rb.AddForce(Vector3.left * thrust * 7, ForceMode.Acceleration);
                }
                else
                {
                    goesRight = false;
                }
            }

        }
        if (Input.GetKey(GameManager.GM.rightFP))
        {
            if (!goesLeft)
            {
                if (rb.velocity.x < upSpeed)
                {
                    //upSpeed += 0.2f;
                    rb.AddForce(Vector3.right * thrust, ForceMode.Acceleration);
                    goesRight = true;
                    goesLeft = false;
                }
            }
            else
            {
                if (rb.velocity.x <= 0)
                {
                    rb.AddForce(Vector3.right * thrust * 7, ForceMode.Acceleration);
                }
                else
                {
                    goesLeft = false;
                }
            }
        }
    }

    private void OnGUI()
    {
        GUI.BeginGroup(new Rect(0,0, 100, 100));
        GUI.Label(new Rect(0, 0, 100, 100), (Vector3.up * thrust).ToString());
        GUI.Label(new Rect(0, 25, 100, 100), upSpeed.ToString());
        GUI.Label(new Rect(0, 50, 100, 100), downSpeed.ToString());
        GUI.Label(new Rect(0, 75, 100, 100), rb.velocity.ToString());
        GUI.EndGroup();
    }
}
