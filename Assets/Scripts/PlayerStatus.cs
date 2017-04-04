using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private bool timeAdded = false;

    private float distanceToWin = 1500f;
    public static bool atTheEnd = false;

    /// Heat bar
    Vector2 barPos = new Vector2(0, 145);
    Vector2 barSize = new Vector2(200, 25);

    //public Texture2D barEmpty;
    //public Texture2D barFull;


    // Can't be attracted for x seconds after he revived
    public static bool reviveProtection = false;
    public static float protectionTimer = 3f;

    // Hearts
    public Texture hearts;

    // Warning
    public static bool redWarning = false;
    public static bool orangeWarning = false;
    public static bool yellowWarning = false;
    public static bool blueWarning = false;

    // Checks if there is no sun around
    private GameObject[] suns;
    private GameObject[] bHoles;
    private GameObject[] sSuns;
    private bool foreverAlone;

    // Checks if the player is attracted by a black hole, used for timer
    public static bool feelingOldYet;

    // Saves the tag of who killed the player
    public static string killedBy;

    // Used for timer
    private string timerLabel;
    public static float time;
    private float startTime;

    // Font used for labels
    private float uiBaseScreenHeight = 700f;
    public Font starFont;
    public static bool showLabel;

    // Saving the closest planet
    /*
    private GameObject gravityPlanet;
    private GameObject gravityStar;
    private Gravity gravityScriptPlanet;
    private StarGravity gravityScriptStar;
    private float customDistance;
    */

    ////public static bool isAttracted;
    //public static string planetName;
    //public static string starName;

    //// When killed be meteors
    //private bool deadBySnuSnu;

    // A vector that contains the number of lives the player has
    static bool[] HP = new bool[3];
    private int count; // Vector's length

    // Checks if the camera should follow the player or not
    public static bool cameraFollow = true;

    // Checks if the player is alive
    public static bool isAlive = true;

    // The amount of maximum heat
    public static float heatAmount;
    
        // If we ever want to change the heat from only one place which we should though
        // but what do i know
    public static float heatDamageStatic;
    public float heatDamage;
    public static float sunHeatGainStatic;
    public float sunHeatGain;
    public static float chkHeatGainStatic;
    public float chkHeatGain;


    // Shows a warning if the player is on a collision course with a planet / star
    public static bool warning = false;
    public static bool itsAGo = false;

    private void Start()
    {
<<<<<<< HEAD
=======
        
        heartHeight = hearts.width;
        heartWidth = hearts.height;

>>>>>>> level-branch
        suns = GameObject.FindGameObjectsWithTag("Star");
        bHoles = GameObject.FindGameObjectsWithTag("Black Hole");
        sSuns = GameObject.FindGameObjectsWithTag("Save Star");

        if (suns.Length == 0 && bHoles.Length == 0 && sSuns.Length == 0)
        {
            foreverAlone = true;
        }

        heatAmount = 100f; // The amount of heat when the game starts
        heatDamageStatic = heatDamage;
        sunHeatGainStatic = sunHeatGain;
        chkHeatGainStatic = chkHeatGain;

        count = 0;
        //HP = new bool[3];
        for (int i = 0; i < HP.Length; i++)
            HP[i] = true;

        //deadBySnuSnu = false;
        showLabel = false;
        //customDistance = 0f;
        killedBy = "Eter";
        feelingOldYet = false;
        startTime = Time.time;
        time = 0.0f;
    }

    private void Update()
    {
        if(reviveProtection)
        {
            protectionTimer -= Time.deltaTime;
            if((int)protectionTimer == 0)
            {
                reviveProtection = false;
                protectionTimer = 3f;
            }
        }

        if(foreverAlone)
        {
            if (isAlive)
            {
                if (heatAmount >= 0)
                {
                    heatAmount -= heatDamage * Time.deltaTime;
                }
                else
                {
                    if ((heatAmount >= 0 && heatAmount < 1) || heatAmount < 0)
                    {
                        isAlive = false;
                        killedBy = "Heat";
                    }
                }
            }
        }

        if (heatAmount <= 0)
        {
            isAlive = false;
        }

        ///////
        /*
        if (planetName != null)
        {
            gravityPlanet = GameObject.Find(planetName);
            gravityScriptPlanet = gravityPlanet.GetComponent<Gravity>();
        }
        Debug.Log(planetName + " " + gravityScriptPlanet.earthToPlanetDist.magnitude);
        /*
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
        /*
        if (!isAlive && gravityScriptPlanet.earthToPlanetDist.magnitude >= customDistance && !deadBySnuSnu && killedBy == "Eter")
        {
            ResetLevel();
        }*/


        ////// Timer
        if (isAlive)
        {
            timeAdded = true;
            if (feelingOldYet)
            {
                if (time < 30)
                    time += 0.02f * 1 / StarGravity.earthToStarDist.magnitude * 200;
                else
                    time += 0.02f * 1 / StarGravity.earthToStarDist.magnitude * 100;
            }
            else
            {
                time += 1.0f * 0.02f;
            }
        }
        else
        {
            if (timeAdded)
            {
                time += 5.0f;
                timeAdded = false;
            }
        }

        var minutes = (int)(time / 60);
        var seconds = (int)(time % 60);
        var fraction = (int)(time * 100) % 100;

        timerLabel = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);

        ///
        if(this.transform.position.z >= distanceToWin)
        {
            atTheEnd = true;
            //PlayerPrefs.SetFloat("highscore", time);
        }
    }

    private void OnGUI()
    {
        GUIStyle starStyle = new GUIStyle();
        starStyle.fontSize = GetScaledFontSize(30);
        var textStyle = new GUIStyle();
        textStyle.fontSize = GetScaledFontSize(35);
        var heatTextStyle = new GUIStyle();
        heatTextStyle.fontSize = GetScaledFontSize(20);
        GUI.skin.font = starFont;

        starStyle.normal.textColor = new Color(0.01569f, 0.81569f, 0.86275f);//(4, 208, 220);
        textStyle.normal.textColor = new Color(0.01569f, 0.81569f, 0.86275f);
        heatTextStyle.normal.textColor = new Color(0, 0, 0);

        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

        GUI.Label(ResizeGUI(new Rect(0, 0, 200, 200)), GetComponent<Rigidbody>().velocity.ToString(), starStyle);
        GUI.Label(ResizeGUI(new Rect(0, 30, 200, 200)), "Max Speed: " + Controller.maxSpeedStatic.ToString(), starStyle);

        // THE HEARTS MAN, THE HEARTS
        if(count==0)
        {
            GUI.DrawTexture(ResizeGUI(new Rect(0, 80, 50, 50)), hearts);
            GUI.DrawTexture(ResizeGUI(new Rect(50, 80, 50, 50)), hearts);
            GUI.DrawTexture(ResizeGUI(new Rect(100, 80, 50, 50)), hearts);
        }
        else
        if(count==1)
        {
            GUI.DrawTexture(ResizeGUI(new Rect(0, 80, 50, 50)), hearts);
            GUI.DrawTexture(ResizeGUI(new Rect(50, 80, 50, 50)), hearts);
        }
        else
            if(count==2)
        {
            GUI.DrawTexture(ResizeGUI(new Rect(0, 80, 50, 50)), hearts);
        }

        //// 

        EditorGUI.ProgressBar(ResizeGUI(new Rect(barPos.x, barPos.y, barSize.x - 6, barSize.y)), heatAmount / 100, "");

        GUI.Label(ResizeGUI(new Rect(60, 140, 200, 200)), string.Format("{0:00.00}", heatAmount), heatTextStyle);

        GUI.Label(ResizeGUI(new Rect(0, 180, 100, 100)), "Status: " + (isAlive == false || count == HP.Length ? "Dead" : "Alive"), starStyle);
        GUI.EndGroup();

        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        if (isAlive)
        {
            GUI.Label(ResizeGUI(new Rect(443, 72, 100, 100)), showLabel ? "YOU ARE REACHING THE OUTER BORDER OF THE GALAXY, RETURN!" : "", textStyle);
        }
        else
        {
            GUI.Label(ResizeGUI(new Rect(373, 72, 100, 100)), "YOU HAVE FAILED TO BRING HUMANITY TO SAFETY, THEREFOR, YOU SHALL DIE WITH IT!", textStyle);
        }

        GUI.Label(ResizeGUI(new Rect(1700, 2, 100, 100)), timerLabel, textStyle);
        GUI.EndGroup();
    }

    Rect ResizeGUI(Rect _rect)
    {
        float FilScreenWidth = _rect.width / 1920;
        float rectWidth = FilScreenWidth * Screen.width;
        float FilScreenHeight = _rect.height / 1080;
        float rectHeight = FilScreenHeight * Screen.height;
        float rectX = (_rect.x / 1920) * Screen.width;
        float rectY = (_rect.y / 1080) * Screen.height;

        return new Rect(rectX, rectY, rectWidth, rectHeight);
    }

    private int GetScaledFontSize(int baseFontSize)
    {
        float uiScale = Screen.height / uiBaseScreenHeight;
        int scaledFontSize = Mathf.RoundToInt(baseFontSize * uiScale);
        return scaledFontSize;
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
            //deadBySnuSnu = true;
        }
    }

    public void ResetLevel()
    {
        isAlive = true;
        Controller.ignoreKey = false;
        cameraFollow = true;
        warning = false;
        time = startTime;
    }

    public void ResetLife()
    {
        for (int i = 0; i < HP.Length; i++)
        {
            HP[i] = true;
        }
        count = 0;
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
