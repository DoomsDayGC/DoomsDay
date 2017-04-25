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
            VideoConfig.SetSettings("Low");
        }
        if (this.name == "Medium")
        {
            VideoConfig.SetSettings("Medium");
        }
        if (this.name == "High")
        {
            VideoConfig.SetSettings("High");
        }
        
        // Antialiasing
        if (this.name == "AA")
        {
            if(GetComponent<Toggle>().isOn)
            {
                VideoConfig.SetAA(8);
            }
            else
            {
                VideoConfig.SetAA(0);
            }
        }
        
        // Resolution
        if(this.name == "Resolution")
        {
            if(GetComponent<Dropdown>().value == 0)
            {
                VideoConfig.SetResolution(0, 3);
            }
            else
            if (GetComponent<Dropdown>().value == 1)
            {
                VideoConfig.SetResolution(1, 3);
            }
            else
            if (GetComponent<Dropdown>().value == 2)
            {
                VideoConfig.SetResolution(2, 3);
            }
            else
            if (GetComponent<Dropdown>().value == 3)
            {
                VideoConfig.SetResolution(3, 3);
            }
        }
        Debug.Log("da");
    }

}
