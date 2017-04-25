using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoConfig : MonoBehaviour {

    public void SetDefaults()
    {
        SetSettings("High");
        SetResolution(0, 1);
        SetAA(2);
        SetVsync(1);
    }

    public static void SetResolution(int res, int full)
    {
        bool fs = Convert.ToBoolean(full);

        switch(res)
        {
            case 0:
                Screen.SetResolution(1920, 1080, fs);
                break;
            case 1:
                Screen.SetResolution(1600, 900, fs);
                break;
            case 2:
                Screen.SetResolution(1280, 1024, fs);
                break;
            case 3:
                Screen.SetResolution(1280, 800, fs);
                break;
        }
    }

    public static void SetAA(int samples)
    {
        if (samples == 0 || samples == 2 || samples == 4 || samples == 8)
        {
            QualitySettings.antiAliasing = samples;
        }
    }

    public static void SetVsync(int sync)
    {
        QualitySettings.vSyncCount = sync;
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
        SetResolution(PlayerPrefs.GetInt("Custom_Resolution"), PlayerPrefs.GetInt("Custom_Full"));
        SetAA(PlayerPrefs.GetInt("Custom_AA"));
        SetVsync(PlayerPrefs.GetInt("Custom_Sync"));
    }
}
