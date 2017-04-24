using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Highscore : MonoBehaviour
{
    private bool inTutorial = false;

    private float uiBaseScreenHeight = 1200f;

    public static float highScore;

    private float minutes, seconds, fraction;
    private string highScoreLabel;

	// Use this for initialization
	void Start ()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Tutorial")
        {
            inTutorial = true;
        }
        else
        {
            inTutorial = false;
        }

        if (PlayerPrefs.GetInt("started") == 0)
        {
            PlayerPrefs.SetFloat("highscore", 600f);
        }
        highScore = PlayerPrefs.GetFloat("highscore");
	}
	
	// Update is called once per frame
	void Update ()
    {
        minutes = (int)(highScore / 60);
        seconds = (int)(highScore % 60);
        fraction = (int)(highScore * 100) % 100;
        //Debug.Log(PlayerStatus.time + " " + PlayerPrefs.GetFloat("highscore") + " " + PlayerStatus.atTheEnd);
        if (PlayerStatus.atTheEnd)
        {
            if (PlayerStatus.time < highScore)
            {
                highScore = PlayerStatus.time;
                PlayerPrefs.SetFloat("highscore", highScore);
            }
            //PlayerStatus.atTheEnd = false;

            //Debug.Log(highScore);
            minutes = (int)(highScore / 60);
            seconds = (int)(highScore % 60);
            fraction = (int)(highScore * 100) % 100;
        }
        highScoreLabel = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
    }

    private void OnGUI()
    {
        float rx = Screen.width / 1920.0f;
        float ry = Screen.height / 1080.0f;
        //GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(0, new Vector3(0, 1, 0)), new Vector3(rx, ry, 1));

        if (PlayerStatus.showUI)
        {
            var textStyle = new GUIStyle();
            textStyle.fontSize = GetScaledFontSize(45);

            textStyle.normal.textColor = new Color(0.01569f, 0.81569f, 0.86275f);

            GUI.Label((new Rect(1570, 1000, 100, 100)), "Best time: " + (inTutorial ? string.Format("00 : 00 : 00") : highScoreLabel), textStyle);
        }
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
