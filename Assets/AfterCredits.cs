using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterCredits : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(GameManager.GM.exit))
        {
            SceneManager.LoadScene(0);
        }
	}
}
