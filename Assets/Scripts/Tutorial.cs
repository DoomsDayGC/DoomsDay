using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public Font starFont;

    private float time;
    private bool counter = false;

    private string content = "";
    
    private bool paused;

	// Use this for initialization
	void Start () {
        paused = false;
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
        starStyle.fontSize = 50;
        GUI.skin.font = starFont;
        starStyle.normal.textColor = new Color(0.01569f, 0.81569f, 0.86275f);

        //GUI.Label(new Rect(800, 72, 100, 100), "Welcome to the tutorial", starStyle);

        switch(t)
        {
            case 1:
                content = "Welcome to the tutorial";
                break;
            case 4:
                content = "Here we will teach you the basics";
                break;
            case 7:
                content = "To move the player use " + GameManager.GM.upwardFP + ", " + GameManager.GM.downwardFP + ", " + GameManager.GM.leftFP + ", " + GameManager.GM.rightFP;
                break;
            case 13:
                counter = true;
                break;
        }

        GUI.Label(new Rect(400, 72, 100, 100), content, starStyle);

        //Debug.Log(t);
    }

    void PauseGame()
    {
        Time.timeScale = 0.0f;
        paused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1.0f;
        paused = false;
    }
}
