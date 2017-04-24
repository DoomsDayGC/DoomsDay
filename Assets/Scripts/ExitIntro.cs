using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitIntro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this);
        if (Input.GetKey(GameManager.GM.exit))
        {
            Intro.stopIntro = true;
            Intro.faster = true;
            AutoFade.LoadScene("Main Menu", 0, 1, Color.black);
        }
    }
}
