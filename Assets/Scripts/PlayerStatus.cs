using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    static bool[] HP;

    int count;

    public static bool isAlive = true;

    private void Start()
    {
        count = 0;
        HP = new bool[3];
        for (int i = 0; i < HP.Length; i++)
            HP[i] = true;
    }

    private void Update()
    {
        if (!CollisionSystem.isAlive)
            isAlive = false;
    }

    private void OnGUI()
    {
        var k = 0;
        GUI.BeginGroup(new Rect(0, 0, 200, 200));
        for (int i = 0; i < HP.Length; i++)
        {
            GUI.Label(new Rect(k, 80, 50, 50), HP[i].ToString());
            k += 35;
        }
        GUI.Label(new Rect(0, 110, 100, 100), isAlive == false || count == HP.Length ? "Dead" : "Alive");
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
