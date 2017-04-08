using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

    private GameObject canvasObject;
    public void LoadByIndex(int sceneIndex)
    {
        /*
        if (PlayerPrefs.GetInt("started") == 1)
        {
            Debug.Log("da");
            //canvasObject = GameObject.Find("TutorialPanel");
            //canvasObject.SetActive(true);
            canvasObject = GameObject.Find("MainMenuPanel");
            canvasObject.SetActive(false);
        }
        else
        {*/
        if (this.name == "StartButton")
        {
            if (PlayerPrefs.GetInt("started") == 0)
                SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            SceneManager.LoadScene(sceneIndex); 
        }
        //}
    }
}
