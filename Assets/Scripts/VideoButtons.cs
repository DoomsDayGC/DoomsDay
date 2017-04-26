using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoButtons : MonoBehaviour {

    public void OnClick()
    {
        // Quality
        if(this.name == "Low")
        {
            VideoConfig.quality = "Low";
            VideoConfig.SetSettings("Low");
        }
        if (this.name == "Medium")
        {
            VideoConfig.quality = "Medium";
            VideoConfig.SetSettings("Medium");
        }
        if (this.name == "High")
        {
            VideoConfig.quality = "High";
            VideoConfig.SetSettings("High");
        }
        
        // Fullscreen
        if (this.name == "Fullscreen")
        {
            if (GetComponent<Toggle>().isOn)
            {
                VideoConfig.fullscreen = 1;
                Screen.fullScreen = true;
            }
            else
            {
                Screen.fullScreen = false;
                VideoConfig.fullscreen = 0;
            }
        }

        // Resolution
        if (this.name == "Resolution")
        {
            if(GetComponent<Dropdown>().value == 0)
            {
                VideoConfig.res = 0;
                VideoConfig.SetResolution(0, VideoConfig.fullscreen == 0 ? false : true);
            }
            else
            if (GetComponent<Dropdown>().value == 1)
            {
                VideoConfig.res = 1;
                VideoConfig.SetResolution(1, VideoConfig.fullscreen == 0 ? false : true);
            }
            else
            if (GetComponent<Dropdown>().value == 2)
            {
                VideoConfig.res = 2;
                VideoConfig.SetResolution(2, VideoConfig.fullscreen == 0 ? false : true);
            }
            else
            if (GetComponent<Dropdown>().value == 3)
            {
                VideoConfig.res = 3;
                VideoConfig.SetResolution(3, VideoConfig.fullscreen == 0 ? false : true);
            }
        }
    }

    public void SaveAll()
    {
        PlayerPrefs.SetString("Custom_Settings", VideoConfig.quality);
        PlayerPrefs.SetInt("Custom_Resolution", VideoConfig.res);
        PlayerPrefs.SetInt("Custom_Full", VideoConfig.fullscreen);
    }

}
