using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    private float uiBaseScreenHeight = 700f;

    public static float highScore;

    private float minutes, seconds, fraction;
    private string highScoreLabel;

	// Use this for initialization
	void Start ()
    {
        if(PlayerPrefs.GetFloat("highscore") == 0f)
        {
            PlayerPrefs.SetFloat("highscore", 200f);
        }
        highScore = PlayerPrefs.GetFloat("highscore");
	}
	
	// Update is called once per frame
	void Update ()
    {
        minutes = (int)(highScore / 60);
        seconds = (int)(highScore % 60);
        fraction = (int)(highScore * 100) % 100;
        if (PlayerStatus.atTheEnd)
        {
            if (PlayerStatus.time < highScore)
            {
                highScore = PlayerStatus.time;
                PlayerPrefs.SetFloat("highscore", highScore);
            }
            PlayerStatus.atTheEnd = false;

            //Debug.Log(highScore);
            minutes = (int)(highScore / 60);
            seconds = (int)(highScore % 60);
            fraction = (int)(highScore * 100) % 100;
        }
        highScoreLabel = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
    }

    private void OnGUI()
    {
        var textStyle = new GUIStyle();
        textStyle.fontSize = GetScaledFontSize(35);

        textStyle.normal.textColor = new Color(0.01569f, 0.81569f, 0.86275f);

        GUI.Label(ResizeGUI(new Rect(1570, 1000, 100, 100)), "Best time: " + highScoreLabel, textStyle);
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
