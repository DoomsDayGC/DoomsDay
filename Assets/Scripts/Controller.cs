using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Rigidbody rb;
    public float thrust;
    public float maxSpeed;

    bool goesForward = false;
    bool goesDownward = false;
    bool goesRight = false;
    bool goesLeft = false;
    float upSpeed, downSpeed, leftSpeed, rightSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GoesForward();
        GoesDownward();
        leftSpeed = (Vector3.left * thrust).x;
        rightSpeed = (Vector3.right * thrust).x;
    }

    private void GoesForward()
    {
        upSpeed = (Vector3.up * thrust).y;
    }

    private void GoesDownward()
    {
        downSpeed = (Vector3.down * thrust).y;
    }

    // Update is called once per frame
    void Update ()
    {
        
        if (Input.GetKey(GameManager.GM.upwardFP))
        {
            //transform.position += Vector3.up / 8;
            /*if(rb.velocity.y < upSpeed)
                rb.AddForce(Vector3.up * thrust, ForceMode.Acceleration);
            */
            //if (!goesForward)
              //  GoesForward();

            if (rb.velocity.y < upSpeed)
            {
                //upSpeed += 0.2f;
                rb.AddForce(Vector3.up * thrust, ForceMode.Acceleration);
                goesForward = true;
                goesDownward = false;
            }
            
        }
        if(Input.GetKey(GameManager.GM.downwardFP))
        {
            //transform.position += Vector3.down / 8;
            /*
            if(rb.velocity.y > downSpeed)
            {
                rb.AddForce(Vector3.down * thrust, ForceMode.Acceleration);
            }*/
            
            if (!goesForward)
            {
                //if (!goesDownward)
                  //  GoesDownward();
                if (rb.velocity.y > downSpeed)
                {
                    //downSpeed += 0.2f;
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
                    goesForward = false;
                }
                //rb.AddForce(Vector3.down.y * ((Vector3.up * maxSpeed) / thrust) * thrust, ForceMode.Acceleration);
            }
                
        }
        if (Input.GetKey(GameManager.GM.leftFP))
        {
            //transform.position += Vector3.left / 8;
            if ((Vector3.left * thrust).x > -maxSpeed)
                rb.AddForce(Vector3.left * thrust*5, ForceMode.Acceleration);
        }
        if (Input.GetKey(GameManager.GM.rightFP))
        {
            //transform.position += Vector3.right / 8;
            if ((Vector3.right * thrust).x < maxSpeed)
                rb.AddForce(Vector3.right * thrust *5, ForceMode.Acceleration);
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
