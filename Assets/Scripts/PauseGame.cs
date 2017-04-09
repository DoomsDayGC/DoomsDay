using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    bool paused = false;
    GameObject canvasObject;

    bool pressed;

    private void Start()
    {
        canvasObject = GameObject.Find("MainMenuCanvas");
        canvasObject.SetActive(false);
        pressed = false;
    }

    
    // Update is called once per frame
    void Update ()
    {
	    if(Input.GetKey(GameManager.GM.exit))
        {
            pressed = true;
            paused = togglePause();
        }

        if(paused && pressed==false)
        {
            SceneManager.LoadScene(1);
        }
        if(pressed == true)
        {
            SceneManager.LoadScene(0);
        }
	}

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}
