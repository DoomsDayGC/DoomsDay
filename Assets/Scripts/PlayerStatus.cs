using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Font starFont;
    public static bool showLabel;

    private GameObject gravityPlanet;
    private GameObject gravityStar;
    private Gravity gravityScriptPlanet;
    private StarGravity gravityScriptStar;

    //public static bool isAttracted;
    public static string planetName;
    public static string starName;

    // When killed be meteors
    private bool deadBySnuSnu;

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

    private void Update()
    {
        float customDistance = 0f;

        if (planetName != null)
        {
            gravityPlanet = GameObject.Find(planetName);
            gravityScriptPlanet = gravityPlanet.GetComponent<Gravity>();
        }
        if (starName != null)
        {
            gravityStar = GameObject.Find(starName);
            gravityScriptStar = gravityStar.GetComponent<StarGravity>();
        }
        
        switch(planetName)
        {
            case "Jupiter":
                customDistance = 100;
                break;
            case "Venus":
                customDistance = 50;
                break;
            case "Mercury":
                customDistance = 40;
                break;
            case "Saturn":
                customDistance = 80;
                break;
            case "Neptune":
                customDistance = 50;
                break;
            case "Mars":
                customDistance = 30;
                break;   
        }
        
        if (!isAlive && gravityScriptPlanet.earthToPlanetDist.magnitude >= customDistance && !deadBySnuSnu && !gravityScriptStar.isAttractedByStar)
        {
            ResetLevel();
        }
    }

    private void Start()
    {
        heatAmount = 100f; // The amount of heat when the game starts

        count = 0;
        HP = new bool[3];
        for (int i = 0; i < HP.Length; i++)
            HP[i] = true;

        deadBySnuSnu = false;
        showLabel = false;
    }

    private void OnGUI()
    {
        var k = 0;
        GUIStyle starStyle = new GUIStyle();
        starStyle.fontSize = 40;
        GUI.skin.font = starFont;
        //GUI.color = new Color(4,208,220);
        starStyle.normal.textColor = new Color(4, 208, 220);



        GUI.BeginGroup(new Rect(0, 0, 1000, 1000));

        GUI.Label(new Rect(0, 30, 200, 200), GetComponent<Rigidbody>().velocity.ToString(), starStyle);
        GUI.Label(new Rect(0, 60, 200, 200), "Max Speed: " + Controller.maxSpeedStatic.ToString(), starStyle);

        for (int i = 0; i < HP.Length; i++)
        {
            GUI.Label(new Rect(k, 90, 50, 50), HP[i].ToString(), starStyle);
            k += 90;
        }

        GUI.Label(new Rect(0, 120, 200, 200), warning ? "WARNING" : "", starStyle);
        GUI.Label(new Rect(0, 150, 200, 200), "Heat: " + heatAmount.ToString(), starStyle);

        GUI.Label(new Rect(0, 180, 100, 100), "Status: " + (isAlive == false || count == HP.Length ? "Dead" : "Alive"), starStyle);

        GUI.Label(new Rect(0, 210, 600, 400), showLabel ? "YOU ARE REACHING THE OUTER BORDER OF THE GALAXY, RETURN!" : "", starStyle);

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
        {
            isAlive = false;
            deadBySnuSnu = true;
        }
    }

    public void ResetLevel()
    {
        isAlive = true;
        Controller.ignoreKey = false;
        cameraFollow = true;
        warning = false;
    }

    public void ResetLevel(Vector3 poz, bool[] HP, float Heat)
    {
        ResetLevel();
        this.transform.position = poz;
        for (int i = 0; i < HP.Length; i++)
            PlayerStatus.HP[i] = HP[i];
        heatAmount = Heat;
    }
}
