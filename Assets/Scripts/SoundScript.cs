using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour {

    public Slider mySlider;
    public Button button;

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("CurVol");// Set the saved volume
        mySlider.value = AudioListener.volume;
        mySlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update ()
    {
        //AudioListener.volume = mySlider.value / 10f;
        if(SaveSoundOnExit.saveSound)
        {
            //PlayerPrefs.SetFloat("CurVol", AudioListener.volume); // This will save the volume of the Audio Source not the slider
            // To save the slider value
            PlayerPrefs.SetFloat("CurVol", mySlider.value);    
            PlayerPrefs.Save();
            //SaveSoundOnExit.saveSound = false;
        }
    }

    public void ValueChangeCheck()
    {
        AudioListener.volume = mySlider.value;
    }
}
