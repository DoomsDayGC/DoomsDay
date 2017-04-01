using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private static Font starFont;

    public static GameObject player;

    public static Vector3 savedPosition;

    private static float time = 5f;
    private static bool counter = false;
    private static string content = "";

    // Use this for initialization
    void Start ()
    {
        player = this.GetComponent<ResizingObjects>().Player;
        starFont = player.GetComponent<PlayerStatus>().starFont;
	}

    private void Update()
    {
        if (!PlayerStatus.isAlive)
        {
            time -= Time.deltaTime;
        }
    }

    public static void Revive()
    {
        if (counter)
        {
            PlayerStatus.reviveProtection = true;
            PlayerStatus.heatAmount = 100;
            PlayerStatus.blueWarning = false;
            PlayerStatus.redWarning = false;
            PlayerStatus.orangeWarning = false;
            PlayerStatus.yellowWarning = false;
            PlayerStatus.isAlive = true;
            PlayerStatus.cameraFollow = true;
            Controller.ignoreKey = false;
            player.transform.position = savedPosition;
            player.GetComponent<PlayerStatus>().ResetLife();
            time = 5f;
            counter = false;
        }
	}

    private void OnGUI()
    {
        if (!PlayerStatus.isAlive)
        { 
            int t = Mathf.FloorToInt(time);

            GUIStyle starStyle = new GUIStyle();
            starStyle.fontSize = 50;
            starStyle.normal.textColor = new Color(0.01569f, 0.81569f, 0.86275f);
            starStyle.alignment = TextAnchor.MiddleCenter;
            GUI.skin.font = starFont;

            GUI.Label(new Rect(Screen.width/2, Screen.height/2 - 370, 100, 100), "Reviving in", starStyle);

            switch (t)
            {
                case 4:
                    content = "3";
                    break;
                case 3:
                    content = "2";
                    break;
                case 2:
                    content = "1";
                    break;
                case 1:
                    content = "0";
                    break;
                case 0:
                    counter = true;
                    break;
            }

            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 - 330, 100, 100), content, starStyle);
        }
    }
}
