using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Image heatBar;

    public static bool showUI = true;

    private bool savedLocation = false;

    //private float distanceToWin = 12009f;
    public static bool atTheEnd = false;
    //public static bool canChange = false;
    private static float transitionTime = 3f;
    private bool inTransition = false;

    // Adding seconds if the player died
    private bool showTimeAddition = false;
    private bool timeAdded = false;
    private bool relativityIsReal = false;

    /// Heat bar
    Vector2 barPos = new Vector2(0, /*145*/90);
    Vector2 barSize = new Vector2(220, 25);

    //public Texture2D barEmpty;
    //public Texture2D barFull;


    // Can't be attracted for x seconds after he revived
    public static bool reviveProtection = false;
    public static float protectionTimer = 3f;
    public static float inviTimer = 10f;
    public static bool inviProtection = false;
    public static bool canDie = true;
    public static float canDieTime = 3f;

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
    private float uiBaseScreenHeight = 1200f;
    public Font starFont;
    public static bool showLabel;

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
        yellowWarning = false;
        orangeWarning = false;
        redWarning = false;
        blueWarning = false;
        cameraFollow = true;

        suns = GameObject.FindGameObjectsWithTag("Sun");
        bHoles = GameObject.FindGameObjectsWithTag("Black Hole");
        sSuns = GameObject.FindGameObjectsWithTag("Checkpoint");

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

        showLabel = false;
        killedBy = "Eter";
        feelingOldYet = false;
        startTime = Time.time;
        time = 0.0f;

    }

    private void Update()
    {
        heatBar.fillAmount = heatAmount / 100f;

        if(reviveProtection)
        {
            protectionTimer -= 0.02f;//0.02f;//
            if ((int)protectionTimer <= 0)
            {
                reviveProtection = false;
                protectionTimer = 3f;
            }
        }

        if (inviProtection)
        {
            inviTimer -= 0.02f;//0.02f;//
            if ((int)inviTimer <= 0)
            {
                inviProtection = false;
                inviTimer = 10f;
                ItemStatus.antiGravInUse = false;
            }
        }

        if (!canDie)
        {
            canDieTime -= 0.02f;
            if ((int)canDieTime <= 0)
            {
                canDie = true;
                canDieTime = 3f;
                ItemStatus.inviInUse = false;
            }
        }

        if (foreverAlone)
        {
            if (isAlive && !atTheEnd)
            {
                if (heatAmount >= 0)
                {
                    heatAmount -= heatDamage * 0.02f;//0.02f;//
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

        ////// Timer
        if (isAlive)
        {
            showTimeAddition = false;
            timeAdded = true;
            if (feelingOldYet)
            {
                //if (time < 30)
                time += 2.0f * 0.02f;
                /*
                time += 0.02f * 1 / StarGravity.earthToStarDist.magnitude * 200;
            else
                time += 0.02f * 1 / StarGravity.earthToStarDist.magnitude * 100;*/
                relativityIsReal = true;
            }
            else
            {
                if (!atTheEnd)
                {
                    time += 1.0f * 0.02f;
                }
                relativityIsReal = false;
            }
        }
        else
        {
            if (timeAdded)
            {
                time += 5.0f;
                showTimeAddition = true;
                timeAdded = false;
            }
        }
        
        var minutes = (int)(time / 60);
        var seconds = (int)(time % 60);
        var fraction = (int)(time * 100) % 100;

        timerLabel = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);

        ///
        /*
        if(this.transform.position.z >= distanceToWin)
        {
            atTheEnd = true;
            //PlayerPrefs.SetFloat("highscore", time);
        }*/

        if (atTheEnd)
        {
            isAlive = true;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (SceneManager.GetActiveScene().name == "Tutorial" && !inTransition)
            {
                AutoFade.LoadScene("Lets call it a test", 3, 1, Color.black);
                inTransition = true;
            }
            if (SceneManager.GetActiveScene().name == "Lets call it a test" && !inTransition)
            {
                AutoFade.LoadScene("Credits", 3, 2, Color.black);
                inTransition = true;
                //etFini = true;
            }
            transitionTime -= 0.02f;
            if((int)transitionTime <= 0)
            {
                showUI = false;
                atTheEnd = false;
                //if (!etFini)
               // {
                    BackToStart();
                //atTheEnd = false;
                //}
            }
        }
       // etFini = false;
        if(SceneManager.GetActiveScene().name == "Lets call it a test")
        {
            if (!savedLocation)
            {
                showUI = true;
                Checkpoint.savedPosition = this.transform.position;
                savedLocation = true;
            }
            if (inTransition)
            {
                time = 0f;
            }
            transitionTime = 3f;
            inTransition = false;
            atTheEnd = false;
        }
        if (SceneManager.GetActiveScene().name == "Credits")
        {
            transitionTime = 3f;
            inTransition = false;
            atTheEnd = false;
        }

    }

    private void OnGUI()
    {
        if (showUI)
        {
            float rx = Screen.width / 1920.0f;
            float ry = Screen.height / 1080.0f;
            //GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(0, new Vector3(0, 1, 0)), new Vector3(rx, ry, 1));

            GUIStyle starStyle = new GUIStyle();
            starStyle.fontSize = GetScaledFontSize(40);
            var textStyle = new GUIStyle();
            textStyle.fontSize = GetScaledFontSize(45);
            var heatTextStyle = new GUIStyle();
            heatTextStyle.fontSize = GetScaledFontSize(30);
            GUI.skin.font = starFont;

            starStyle.normal.textColor = new Color(0.01569f, 0.81569f, 0.86275f);//(4, 208, 220);
            textStyle.normal.textColor = new Color(0.01569f, 0.81569f, 0.86275f);
            heatTextStyle.normal.textColor = new Color(0, 0, 0);

            //GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

            //GUI.Label(ResizeGUI(new Rect(0, 0, 200, 200)), GetComponent<Rigidbody>().velocity.ToString(), starStyle);
            //GUI.Label(ResizeGUI(new Rect(0, 30, 200, 200)), "Max Speed: " + Controller.maxSpeedStatic.ToString(), starStyle);

            // THE HEARTS MAN, THE HEARTS
            if (count == 0)
            {
                GUI.DrawTexture((new Rect(0, /*80*/20, 50, 50)), hearts);
                GUI.DrawTexture((new Rect(50, 20, 50, 50)), hearts);
                GUI.DrawTexture((new Rect(100, 20, 50, 50)), hearts);
            }
            else
            if (count == 1)
            {
                GUI.DrawTexture((new Rect(0, 20, 50, 50)), hearts);
                GUI.DrawTexture((new Rect(50, 20, 50, 50)), hearts);
            }
            else
                if (count == 2)
            {
                GUI.DrawTexture((new Rect(0, 20, 50, 50)), hearts);
            }

            //// 
#if UNITY_EDITOR
            //UnityEditor.EditorGUI.ProgressBar(ResizeGUI(new Rect(barPos.x, barPos.y, barSize.x - 6, barSize.y)), heatAmount / 100, "");
#endif
            GameObject.Find("HeatCanvas").SetActive(true);
            //GameObject.Find("BckHeat").transform.position = new Vector2(110, 970);
            GameObject.Find("HeatText").GetComponent<Text>().text = string.Format("{0:00.00}", heatAmount);
            //GUI.Label((new Rect(85, /*140*/86, 200, 200)), string.Format("{0:00.00}", heatAmount), heatTextStyle);

            //GUI.Label(ResizeGUI(new Rect(0, 180, 100, 100)), "Status: " + (isAlive == false || count == HP.Length ? "Dead" : "Alive"), starStyle);
            // GUI.EndGroup();

            //GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
            if (isAlive)
            {
                GUI.Label((new Rect(443, 72, 100, 100)), showLabel ? "YOU ARE REACHING THE OUTER BORDER OF THE GALAXY, RETURN!" : "", textStyle);
            }
            else
            {
                GUI.Label((new Rect(373, 72, 100, 100)), "YOU HAVE FAILED TO BRING HUMANITY TO SAFETY, THEREFOR, YOU SHALL DIE WITH IT!", textStyle);
            }

            GUI.Label((new Rect(1700, 2, 100, 100)), timerLabel, textStyle);

            if (showTimeAddition)
            {
                GUI.Label((new Rect(1740, 35, 100, 100)), "+ 05 : 00", textStyle);
            }
            if (relativityIsReal)
            {
                if (!showTimeAddition)
                    GUI.Label((new Rect(1810, 35, 100, 100)), "X 2", textStyle);
            }
            //GUI.EndGroup();
        }
        //else
        //{
        //    GameObject.Find("HeatCanvas").SetActive(false);
        //}
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
        if(col.collider.tag == "Meteor" && canDie)
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
        }

        if (col.collider.tag == "Meteor")
        {
            //col.gameObject.SetActive(false);
        }
    }

    public void ResetLevel()
    {
        isAlive = true;
        Controller.ignoreKey = false;
        //Nebula.unfroze = true;
        cameraFollow = true;
        warning = false;
        time = startTime;
    }

    private void BackToStart()
    {
        isAlive = true;
        cameraFollow = true;
        ResetLife();
        heatAmount = 100f;
        Controller.ignoreKey = false;
        //Nebula.unfroze = true;
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
    public void SaveSettings()
    {
        pSavedLocation = this.transform.position;
        pSavedHeat = heatAmount;
        pTime = time;
        pMeteorLife = count;
    }*/
}
