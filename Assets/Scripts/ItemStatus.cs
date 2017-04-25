using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    public static bool pickedItem = false;

    public static bool hasInvi = false;
    public static bool hasAntiGrav = false;
    public static bool hasHeat = false;

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
	
	// Update is called once per frame
	void Update ()
    {		
        if(Input.GetKey(GameManager.GM.useItem1))
        {
            if(hasAntiGrav)
            {
                PlayerStatus.inviProtection = true;
                hasAntiGrav = false;
            }
        }
        if (Input.GetKey(GameManager.GM.useItem2))
        {
            if (hasHeat)
            {
                PlayerStatus.heatAmount = 100f;
                hasHeat = false;
            }
        }
        if (Input.GetKey(GameManager.GM.useItem3))
        {
            if (hasInvi)
            {
                PlayerStatus.canDie = false;
                hasInvi = false;
            }
        }
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


        GUI.Label(new Rect(720, 1000, 100, 100), hasAntiGrav? "Anti Gravity" : "", starStyle);
        GUI.Label(new Rect(720 + 190, 1000, 100, 100), hasHeat? "Heat Refill" : "", starStyle);
        GUI.Label(new Rect(720 + 350, 1000, 100, 100), hasInvi? "No Meteor Allowed" : "", starStyle);

        GUI.EndGroup();
    }

    private int GetScaledFontSize(int baseFontSize)
    {
        float uiScale = Screen.height / uiBaseScreenHeight;
        int scaledFontSize = Mathf.RoundToInt(baseFontSize * uiScale);
        return scaledFontSize;
    }
}
