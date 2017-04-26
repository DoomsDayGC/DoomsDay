using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoConfig : MonoBehaviour {

    public Toggle full;
    public Dropdown resDrop;

    public static int fullscreen = 1;
    public static int res;
    public static string quality;

    private void Start()
    {
        full.isOn = PlayerPrefs.GetInt("Custom_Full") == 0 ? false : true;
        resDrop.value = PlayerPrefs.GetInt("Custom_Resolution");
        LoadAll();
    }

    public void SetDefaults()
    {
        SetSettings("High");
        SetResolution(0, true);
    }

    public static void SetResolution(int res, bool full)
    {
        //bool fs = Convert.ToBoolean(full);

        switch(res)
        {
            case 0:
                Screen.SetResolution(1920, 1080, full);
                break;
            case 1:
                Screen.SetResolution(1600, 900, full);
                break;
            case 2:
                Screen.SetResolution(1280, 1024, full);
                break;
            case 3:
                Screen.SetResolution(1280, 800, full);
                break;
        }
    }

    public static void SetSettings(string name)
    {
        switch (name)
        {
            case "Low":
                QualitySettings.SetQualityLevel(0);
                break;
            case "Medium":
                QualitySettings.SetQualityLevel(1);
                break;
            case "High":
                QualitySettings.SetQualityLevel(2);
                break;
        }
    }

    public static void LoadAll()
    {
        SetSettings(PlayerPrefs.GetString("Custom_Settings"));
        SetResolution(PlayerPrefs.GetInt("Custom_Resolution"), PlayerPrefs.GetInt("Custom_Full") == 0? false : true);
    }
}
