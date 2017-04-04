using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private float upAndDownArrow = 0f;
    private bool showArrow = true;

    public Texture arrow;

    private float uiBaseScreenHeight = 700f;

    public Font starFont;

    private float time;
    private bool counter = false;

    private string content = "";

    private int xPos, yPos;

    private GUIStyle currentStyle = null;

    // Use this for initialization
    void Start () {
        //PauseGame();
        time = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*
        Debug.Log(paused);
	    if(Input.GetKey(GameManager.GM.pause))
        {
            if (!paused)
                PauseGame();
            else
                ResumeGame();
        }*/

        time += Time.deltaTime;

        //if(showArrow)
        //{
        upAndDownArrow += Time.deltaTime;
        if ((int)upAndDownArrow == 2)
        {
            upAndDownArrow = 0f;
        }
        //}
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

        switch(t)
        {
            case 1:
                content = "Welcome to the tutorial where we will show you the basics";
                break;
            case 5:
                content = "To move the player use " + GameManager.GM.upwardFP + ", " + GameManager.GM.downwardFP + ", " + GameManager.GM.leftFP + ", " + GameManager.GM.rightFP;
                break;
            case 9:
                content = "The hearts represents the number of times you can survive until you are getting hit by meteors.";
                xPos = 180;
                yPos = 63;
                if(showArrow)
                {
                    GUI.DrawTexture(ResizeGUI(new Rect(xPos, yPos, 140, 100)), arrow);
                }
                break;
            case 13:
                showArrow = false;
                counter = true;
                break;
        }

        //if (!counter)
        //{
        //InitStyles();
        //GUI.Box(ResizeGUI(new Rect(xPos, yPos, xSize, ySize)), "", currentStyle);
        
        //}

        GUI.Label(ResizeGUI(new Rect(130, 900, 100, 100)), content, starStyle);
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

    private void InitStyles()
    {
        if (currentStyle == null)
        {
            currentStyle = new GUIStyle(GUI.skin.box);
            currentStyle.normal.background = MakeTex(2, 2, Color.red);//new Color(0f, 1f, 0f, 0.5f));
        }
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
