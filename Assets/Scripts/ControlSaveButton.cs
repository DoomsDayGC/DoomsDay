using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSaveButton : MonoBehaviour {

    Transform menuPanel;
    bool saved = false;

    public void OnClick()
    {
        menuPanel = transform.FindChild("ControlSettingsPanel");

        for (int i = 0; i < 20; i++)
            if (menuPanel.GetChild(i).name == "BackButton" && !saved)
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = "Cancel";
            else if (menuPanel.GetChild(i).name == "BackButton" && saved)
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = "Back";
    }
    
}
