using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private Vector3 initialLocation;

    /// Saving checkpoints from time to time;
    private bool checkpoint0 = false;
    private bool checkpoint1 = false;
    private bool checkpoint2 = false;
    private bool checkpoint3 = false;
    private bool finalCheckpoint = false;

    /// Checks if died before the age
    private bool prematureDeath = false;
    //private bool canSuicide = false;

    /// Used to save the content it displayed before the player being an explorer
    //private bool doraCheck = false;

    /// If the player already leaves the area won't show again
    //private bool butDidItHappen = false;

    public GameObject player;

    /// Checks if the player goes exploring.
    //private bool heSheApacheTried = false;
    private bool DoraTheExplorer = false;
    //private float msgShow = 0f;
    private bool paused = false;

    // Arrow cases
    private bool showCaseArrow = false;

    // Use to flicker the arrow
    private float waitTime = 0f;
    private float upAndDownArrow = 0f;
    private bool showArrow = false;
    private bool waitFor = false;

    private bool showLeftArrow;
    private bool showRightArrow;

    public Texture arrowLeft;
    public Texture arrowRight;

    private float uiBaseScreenHeight = 700f;

    public Font starFont;

    private float time;
    private bool counter = false;

    //private string saveContent = "";
    private string content = "";

    private float xPos, yPos;

    private void Start()
    {
        initialLocation = Vector3.zero;
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
            Checkpoint.savedPosition = Controller.initialPos + new Vector3(0, 0, 3500);
            Checkpoint.Revive();
        }
        if (!PlayerStatus.isAlive && checkpoint3 == true)
        {
            Checkpoint.savedPosition = Controller.initialPos + new Vector3(0, 0, 6340);
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

        if (showCaseArrow && !paused && showLeftArrow)
        {
            Flicker(showLeftArrow);
        }
        else
        if (showCaseArrow && !paused && showRightArrow)
        {
            Flicker(showRightArrow);
        }
        /*
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
        }*/
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
    void Flicker(bool whatArrow)
    {
        if (!waitFor)
        {
            upAndDownArrow += 0.02f;
            showArrow = true;
            whatArrow = true;
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
            whatArrow = false;
        }
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
            if(checkpoint3)
            {
                content = "Don't give up, you're doing great.";
            }
            if(finalCheckpoint)
            {
                content = "Almost there, you got this.";
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
                    checkpoint2 = false;
                    prematureDeath = false;
                }
                if(checkpoint3)
                {
                    time = 105f;
                    checkpoint3 = false;
                    prematureDeath = false;
                }
                if (finalCheckpoint)
                {
                    time = 155f;
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
                case 11:
                    content = "The bar represents the amount of heat you have. When you get to 0 you will freeze and die. So don't get to 0.";
                    xPos = 200;
                    yPos = 110;
                    showCaseArrow = true;
                    showLeftArrow = true;
                    break;
                case 19:
                    DoraTheExplorer = false;
                    //doraCheck = false;
                    showCaseArrow = false;
                    showArrow = false;
                    showLeftArrow = false;
                    content = "Passing the arrows on the sides will make your heat deplete faster.";
                    break;
                case 26:
                    DoraTheExplorer = false;
                    //doraCheck = false;
                    showCaseArrow = false;
                    showArrow = false;
                    showLeftArrow = false;
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
                case 63:
                    content = "Getting past a planet while attracted by it gives you a slight speed boost.";
                    break;
                case 69:
                    content = "";
                    break;
                case 95:
                    content = "Great job back there.";
                    break;
                case 98:
                    content = "The hearts represents the number of times you can get hit by a meteor without dying.";
                    xPos = 200;
                    yPos = 60;
                    showCaseArrow = true;
                    showLeftArrow = true;
                    break;
                case 105:
                    showCaseArrow = false;
                    showArrow = false;
                    showLeftArrow = false;
                    content = "Let's see how you can dodge the incoming meteors now.";
                    break;
                case 110:
                    content = "";
                    break;
                case 125:
                    content = "Quite easy, right? Here comes a Star. Gravitating around it gives you heat. You can still die if you get too close.";
                    break;
                case 135:
                    content = "";
                    break;
                case 142:
                    content = "Meet your new best friend, the Checkpoint Star. Passing it saves your progress.";
                    break;
                case 149:
                    content = "";
                    break;
                case 162:
                    showCaseArrow = true;
                    showRightArrow = true;
                    xPos = 1540;
                    yPos = 1.6f;
                    content = "Here you have the timer. If you die, 5 seconds are added to it. It's purpose is the Highscore.";
                    break;
                case 169:
                    showCaseArrow = false;
                    showArrow = false;
                    showRightArrow = false;
                    content = "";
                    break;
                case 171:
                    content = "And finally, the Black Hole. Due to relativity times goes twice as fast near it.";
                    break;
                case 176:
                    content = "";
                    break;
                case 186:
                    content = "This ends the tutorial. Have fun out there and dont't forget, humanity is in your hands.";
                    break;
                case 192:
                    content = "";
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

            if ((int)time > 48 && (int)time < 97)
            {
                checkpoint2 = true;
            }
            else
            {
                checkpoint2 = false;
            }

            if((int)time>=97)
            {
                checkpoint3 = true;
            }
            if(initialLocation!=Checkpoint.savedPosition)
            {
                checkpoint3 = false;
            }
        }
        else
        {
            if (DoraTheExplorer)
            {
               // content = "I can see that you can't stay put. This zone is dangerous for your heat. Your heat depletes faster beyond the bounds.";
            }
        }

        if (showCaseArrow && showArrow)
        {
            if (showLeftArrow)
            {
                GUI.DrawTexture(ResizeGUI(new Rect(xPos, yPos, 140, 100)), arrowLeft);
            }
            else
                if(showRightArrow)
            {
                GUI.DrawTexture(ResizeGUI(new Rect(xPos, yPos, 140, 100)), arrowRight);
            }
        }

        GUI.Label(ResizeGUI(new Rect(130, 900, 100, 100)), content, starStyle);
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
