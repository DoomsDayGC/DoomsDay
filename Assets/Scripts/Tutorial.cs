using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private float uiBaseScreenHeight = 700f;

    public Font starFont;

    private float time;
    private bool counter = false;

    private string content = "";

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

        //GUI.Label(new Rect(800, 72, 100, 100), "Welcome to the tutorial", starStyle);

        switch(t)
        {
            case 1:
                content = "Welcome to the tutorial where we will show you the basics";
                break;
            case 5:
                content = "To move the player use " + GameManager.GM.upwardFP + ", " + GameManager.GM.downwardFP + ", " + GameManager.GM.leftFP + ", " + GameManager.GM.rightFP;
                break;
            case 13:
                counter = true;
                break;
        }

        GUI.Box(ResizeGUI(new Rect(200, 200, 300, 300)), "");
        //GUI.Label(ResizeGUI(new Rect(200, 200, 300, 300)), "", Color.red);
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
