﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    // A vector that contains the number of lives the player has
    static bool[] HP;
    private int count; // Vector's length

    // Checks if the camera should follow the player or not
    public static bool cameraFollow = true;

    // Checks if the player is alive
    public static bool isAlive = true;

    // The amount of maximum heat
    public static float heatAmount;

    // Shows a warning if the player is on a collision course with a planet / star
    public static bool warning = false;
    public static bool itsAGo = false;


    private void Start()
    {
        heatAmount = 100f; // The amount of heat when the game starts

        count = 0;
        HP = new bool[3];
        for (int i = 0; i < HP.Length; i++)
            HP[i] = true;
    }

    private void OnGUI()
    {
        var k = 0;
        GUI.BeginGroup(new Rect(0, 0, 200, 200));

        GUI.Label(new Rect(0, 20, 200, 200), GetComponent<Rigidbody>().velocity.ToString());
        GUI.Label(new Rect(0, 40, 200, 200), "Max Speed: " + Controller.maxSpeedStatic.ToString());

        for (int i = 0; i < HP.Length; i++)
        {
            GUI.Label(new Rect(k, 80, 50, 50), HP[i].ToString());
            k += 35;
        }

        GUI.Label(new Rect(0, 110, 200, 200), warning ? "WARNING" : "");
        GUI.Label(new Rect(0, 130, 200, 200), "Heat: " + heatAmount.ToString());

        GUI.Label(new Rect(0, 150, 100, 100), "Status: " + (isAlive == false || count == HP.Length ? "Dead" : "Alive"));

        GUI.EndGroup();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Meteor")
        {
            for (int i = 0; i < HP.Length; i++)
            {
                if(HP[i] == true)
                {
                    count++;
                    HP[i] = false;
                    break;
                }
            }
        }

        if (count == HP.Length)
            isAlive = false;
    }
}
