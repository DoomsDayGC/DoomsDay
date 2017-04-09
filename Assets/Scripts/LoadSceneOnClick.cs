using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    private GameObject canvasObject;

    public void LoadByIndex(int sceneIndex)
    {
        if (this.name == "StartButton")
        {
            if (PlayerPrefs.GetInt("started") == 0)
                SceneManager.LoadScene(sceneIndex);
            /*
            if(Controller.pause == true)
            {
                SceneManager.LoadScene("Level Test");
                Controller.pause = false;

            }*/
        }
        else
        {
            SceneManager.LoadScene(sceneIndex); 
        }
    }
}
