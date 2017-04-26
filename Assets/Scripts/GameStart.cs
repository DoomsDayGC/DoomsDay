using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button startButton;
    public GameObject tutorialPanel;

    void Start ()
    {
        //PlayerPrefs.SetInt("started", 0);
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        VideoConfig.LoadAll();
    }

    
    void TaskOnClick()
    {
        if (PlayerPrefs.GetInt("started") == 0)
        {
            tutorialPanel.SetActive(false);
            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            tutorialPanel.SetActive(true);
        }
    }

}
