using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    //public GameObject MenuCanvas;
    private GameObject canvasObject;
    public Button startButton;
    public GameObject tutorialPanel;
    // Use this for initialization
    void Start ()
    {
        //PlayerPrefs.SetInt("started", 0);
        /*
        if (PlayerPrefs.GetInt("started") == 1)
        {
            PlayerPrefs.SetInt("started", 1);
        }*/

        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        /*
        if (PlayerPrefs.GetInt("started") == 0)
        {
            PlayerPrefs.SetInt("started", 0);
        }*/
        
        /*
        if (PlayerPrefs.GetInt("started") == 1)
        {
            canvasObject = GameObject.Find("TutorialPanel");
            canvasObject.SetActive(false);
        }*/
        //SceneManager.LoadScene(0);
        // MenuCanvas.SetActive(false);
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
