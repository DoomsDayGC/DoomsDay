using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    float speed = 0.2f;
    public static bool crawling = false;
    // Use this for initialization
    void Start()
    {
        // init text here, more space to work than in the Inspector (but you could do that instead)
        var tc = GetComponent<GUIText>();
        var creds = "Credits";
        creds += "ScotchBoard Studios crew";
        creds += "Level Designer:\nFlavius Alb\n";
        creds += "Lead Programmer:\nRobert Chiu\n";
        creds += "Graphic Designer and Gravity Hater:\nCristina Volinteriu\n";
        creds += "With great help from";
        creds += "Level Designer Mentor:\nAurelian Talpasanu\n";
        creds += "Programmer Mentor:\nSulea Cosmin\n";
    }

    // Update is called once per frame
    void Update()
    {
        if (!crawling)
            return;
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (gameObject.transform.position.y > .8)
        {
            crawling = false;
        }
    }
}
