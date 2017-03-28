using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private string timerLabel;
    private float time;
    private float minutes;

    // Font used for labels
    public Font starFont;
    public static bool showLabel;

    // Saving the closest planet
    private GameObject gravityPlanet;
    private GameObject gravityStar;
    private Gravity gravityScriptPlanet;
    private StarGravity gravityScriptStar;
    private float customDistance;

    //public static bool isAttracted;
    public static string planetName;
    public static string starName;

    // When killed be meteors
    private bool deadBySnuSnu;
    public static bool deadByStar;

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

        deadByStar = false;
        deadBySnuSnu = false;
        showLabel = false;
        customDistance = 0f;
        minutes = 0;
    }

    private void Update()
    {
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
        Debug.Log(deadByStar);
        //Debug.Log(StarGravity.atras);
        //Debug.Log(planetName + " " + gravityScriptPlanet.earthToPlanetDist.magnitude + " " + gravityScriptStar.isAttractedByStar);
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

        ////// Timer
        if(isAlive)
            time += Time.deltaTime;

        if (time / 60 == 1)
        {
            minutes++; //Divide the guiTime by sixty to get the minutes.
        }
        var seconds = time % 60; //Use the euclidean division for the seconds.

        timerLabel = string.Format("{0:00} : {1:00}", minutes, seconds);

    }

    private void OnGUI()
    {
        var k = 0;
        GUIStyle starStyle = new GUIStyle();
        starStyle.fontSize = 40;
        GUI.skin.font = starFont;
        starStyle.normal.textColor = new Color(0.01569f, 0.81569f, 0.86275f);//(4, 208, 220);



        GUI.BeginGroup(new Rect(0, 0, 300, 300));

        GUI.Label(new Rect(0, 0, 200, 200), GetComponent<Rigidbody>().velocity.ToString(), starStyle);
        GUI.Label(new Rect(0, 30, 200, 200), "Max Speed: " + Controller.maxSpeedStatic.ToString(), starStyle);

        for (int i = 0; i < HP.Length; i++)
        {
            GUI.Label(new Rect(k, 90, 50, 50), HP[i].ToString(), starStyle);
            k += 90;
        }

        GUI.Label(new Rect(0, 120, 200, 200), warning ? "WARNING" : "", starStyle);
        GUI.Label(new Rect(0, 150, 200, 200), "Heat: " + string.Format("{0:00.00}", heatAmount), starStyle);

        GUI.Label(new Rect(0, 180, 100, 100), "Status: " + (isAlive == false || count == HP.Length ? "Dead" : "Alive"), starStyle);
        GUI.EndGroup();

        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        if (isAlive)
        {
            GUI.Label(new Rect(Screen.width / 2 - 500, Screen.height / 2 - 400, 600, 400), showLabel ? "YOU ARE REACHING THE OUTER BORDER OF THE GALAXY, RETURN!" : "", starStyle);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 600, Screen.height / 2 - 400, 600, 400), "YOU HAVE FAILED TO BRING HUMANITY TO SAFETY, THEREFOR, YOU SHALL DIE WITH IT!", starStyle);
        }

        GUI.Label(new Rect(Screen.width / 2 + 840, Screen.height / 2 - 460, 300, 300), timerLabel, starStyle);
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
    /*
    public void ResetLevel(Vector3 poz, bool[] HP, float Heat)
    {
        ResetLevel();
        this.transform.position = poz;
        for (int i = 0; i < HP.Length; i++)
            PlayerStatus.HP[i] = HP[i];
        heatAmount = Heat;
    }*/
}
