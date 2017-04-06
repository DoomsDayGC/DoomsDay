using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private bool checkpoint0 = false;
    private bool checkpoint1 = false;
    private bool checkpoint2 = false;

    // Checks if died before the age
    private bool prematureDeath = false;
    private bool canSuicide = false;

    // Used to save the content it displayed before the player being an explorer
    private bool doraCheck = false;

    // If the player already leaves the area won't show again
    private bool butDidItHappen = false;

    public GameObject player;

    // Checks if the player goes exploring.
    private bool heSheApacheTried = false;
    private bool DoraTheExplorer = false;
    private float msgShow = 0f;
    private bool paused = false;

    // Arrow cases
    private bool showCaseArrow = false;

    // Use to flicker the arrow
    private float waitTime = 0f;
    private float upAndDownArrow = 0f;
    private bool showArrow = false;
    private bool waitFor = false;

    public Texture arrow;

    private float uiBaseScreenHeight = 700f;

    public Font starFont;

    private float time;
    private bool counter = false;

    private string saveContent = "";
    private string content = "";

    private int xPos, yPos;

    private GUIStyle currentStyle = null;

    // Use this for initialization
    void Start ()
    {
        time = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!PlayerStatus.isAlive && checkpoint1 == true)
        {
            Checkpoint.savedPosition = Controller.initialPos + new Vector3(0, 0, 2200);
            Checkpoint.Revive();
        }
        if (!PlayerStatus.isAlive && checkpoint2 == true)
        {
            Checkpoint.savedPosition = Controller.initialPos + new Vector3(0, 0, 4000);
            Checkpoint.Revive();
        }

        if (!PlayerStatus.isAlive)
        {
            prematureDeath = true;
        }

        if (!prematureDeath)
        {
            time += 0.02f;//
        }

        if (showCaseArrow && !paused)
        {
            Flicker();
        }

        if ((int)time <= 18 && !butDidItHappen)
        {
            DoraTheExplorer = CheckForBounds();
        }

        if (DoraTheExplorer && !butDidItHappen)
        {
            if(!doraCheck)
            {
                saveContent = content;
                doraCheck = true;
            }
            heSheApacheTried = true;
        }

        if(heSheApacheTried && !butDidItHappen)
        { 
            msgShow += 0.02f;
            if((int)msgShow == 5)
            {
                paused = false;
                DoraTheExplorer = false;
                heSheApacheTried = false;
                butDidItHappen = true;
                content = saveContent;
            }
        }
        //Debug.Log(time);
    }

    bool CheckForBounds()
    {
        if (player.transform.position.x >= Controller.initialPos.x + Controller.maxRadiusStatic ||
            player.transform.position.x <= Controller.initialPos.x - Controller.maxRadiusStatic ||
            player.transform.position.y >= Controller.initialPos.y + Controller.maxRadiusStatic ||
            player.transform.position.y <= Controller.initialPos.y - Controller.maxRadiusStatic)
        {
            paused = true;
            return true;
        }
        return false;
    }

    /// Making the arrow flicker and stuff
    void Flicker()
    {
        if (!waitFor)
        {
            upAndDownArrow += 0.02f;
            showArrow = true;
        }
        else
        {
            waitTime += 0.02f;
            if ((int)waitTime == 1)
            {
                waitFor = false;
            }
        }
        if ((int)upAndDownArrow == 1)
        {
            upAndDownArrow = 0f;
            waitTime = 0f;
            waitFor = true;
            showArrow = false;
        }
        //Debug.Log(time);
    }

    private void OnGUI()
    {
        CountDown();
    }

    void CountDown()
    {
        if (counter)
            return;

        int t = Mathf.FloorToInt(time);

        GUIStyle starStyle = new GUIStyle();
        starStyle.fontSize = GetScaledFontSize(30);
        GUI.skin.font = starFont;
        starStyle.normal.textColor = new Color(0.01569f, 0.81569f, 0.86275f);

        if (prematureDeath)
        {
            showCaseArrow = false;
            showArrow = false;
            if (checkpoint0)
            {
                content = "Really? Died already? Let's give it another try.";
            }
            if (checkpoint1)
            {
                content = "It's alright. Let's try again.";
            }
            if (checkpoint2)
            {
                content = "A bit tricky? You can do it.";
            }

            if (PlayerStatus.isAlive)
            {
                if (checkpoint0)
                {
                    time = 0f;
                    prematureDeath = false;
                    checkpoint0 = false;
                }
                if (checkpoint1) 
                {
                    time = 35f;
                    checkpoint1 = false;
                    prematureDeath = false;
                }
                if (checkpoint2)
                {
                    time = 55f;
                    checkpoint1 = false;
                    prematureDeath = false;
                }
                content = "";
            }
        }

        if (!DoraTheExplorer || prematureDeath)
        {
            switch (t)
            {
                case 1:
                    checkpoint0 = true;
                    content = "Welcome to the tutorial where we will show you the basics.";
                    break;
                case 5:
                    content = "To move the player use " + GameManager.GM.upwardFP + ", " + GameManager.GM.downwardFP + ", " + GameManager.GM.leftFP + ", " + GameManager.GM.rightFP + ".";
                    break;
                case 11:/*
                    xPos = 180;
                    yPos = 60;
                    heartCase = true;*/
                    content = "The bar represents the amount of heat you have. When you get to 0 you will freeze and die. So don't get to 0.";
                    xPos = 190;
                    yPos = 110;
                    showCaseArrow = true;
                    break;
                case 19:
                    DoraTheExplorer = false;
                    doraCheck = false;
                    showCaseArrow = false;
                    showArrow = false;
                    content = "Passing the arrows on the sides will make your heat deplete faster.";
                    break;
                case 26:
                    DoraTheExplorer = false;
                    doraCheck = false;
                    showCaseArrow = false;
                    showArrow = false;
                    //canSuicide = true;
                    content = "Hitting a planet will result in your death. Try to avoid them.";
                    break;
                case 33:
                    content = "";
                    break;
                case 48:
                    content = "Great job avoiding those planets. Let's see how you can handle their gravity now.";
                    break;
                case 55:
                    content = "The colors are meant to help you. Yellow means you are attracted, up to red which means that you are too close.";
                    break;
                case 62:
                    content = "";
                    break;
                case 94:
                    content = "Great job. Let's see how you can dodge the incoming meteors now.";
                    break;
                case 98:
                    content = "";
                    break;
                case 200:
                    counter = true;
                    break;
            }

            if ((int)time<32)
            {
                checkpoint0 = true;
            }
            else
            {
                checkpoint0 = false;
            }

            if ((int)time>=32 && (int)time<=48)
            {
                checkpoint1 = true;
            }
            else
            {
                checkpoint1 = false;
            }

            if((int)time>48)
            {
                checkpoint2 = true;
            }
            else
            {
                checkpoint2 = false;
            }
        }
        else
        {
            if (DoraTheExplorer)
            {
                content = "I can see that you can't stay put. This zone is dangerous for your heat. Your heat depletes faster beyond the bounds.";
            }
        }

        if (showCaseArrow && showArrow)
        {
            GUI.DrawTexture(ResizeGUI(new Rect(xPos, yPos, 140, 100)), arrow);
        }

        GUI.Label(ResizeGUI(new Rect(130, 900, 100, 100)), content, starStyle);
    }

    void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1.0f;
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
}
