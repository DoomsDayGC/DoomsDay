using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    private float uiBaseScreenHeight = 1200f;

    private int itemNumber = 0;
    public static int ItemNumber
    {
        get
        {
            return ItemNumber;
        }

        set
        {
            if(value<=3)
            {
                ItemNumber = value;
            }
        }
    }
    
    public static bool hasInvi = false;
    public static bool hasAntiGrav = false;
    public static bool hasHeat = false;
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnGUI()
    {
        GUIStyle starStyle = new GUIStyle();
        starStyle.fontSize = GetScaledFontSize(40);
        starStyle.normal.textColor = new Color(0.01569f, 0.81569f, 0.86275f);

        float rx = Screen.width / 1920.0f;
        float ry = Screen.height / 1080.0f;
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(0, new Vector3(0, 1, 0)), new Vector3(rx, ry, 1));

        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        /*
        GUI.Label(new Rect(Screen.width / 2, Screen.height, 100, 100), "da1");
        GUI.Label(new Rect(Screen.width / 2 + 20, Screen.height, 100, 100), "da2");
        GUI.Label(new Rect(Screen.width / 2 + 40, Screen.height, 100, 100), "da3");
        */
        GUI.Label(new Rect(850, 1000, 100, 100), "da1", starStyle);
        GUI.Label(new Rect(850 + 80, 1000, 100, 100), "da2", starStyle);
        GUI.Label(new Rect(850 + 160, 1000, 100, 100), "da3", starStyle);
        GUI.EndGroup();
    }

    private int GetScaledFontSize(int baseFontSize)
    {
        float uiScale = Screen.height / uiBaseScreenHeight;
        int scaledFontSize = Mathf.RoundToInt(baseFontSize * uiScale);
        return scaledFontSize;
    }
}
