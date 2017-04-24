using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Intro : MonoBehaviour
{ 
    public MovieTexture movie;
    private AudioSource audio;
    public static bool faster = false;
    public static bool stopIntro = false;   

    private float time = 15f;

    // Use this for initialization
    void Start()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        time -= 0.02f;
        if ((int)time == 0f && !faster)
        {
            AutoFade.LoadScene("Main Menu", 3, 1, Color.black);
        }
        if(stopIntro)
        {
            movie.Stop();
            audio.Stop();
        }
    }
}
