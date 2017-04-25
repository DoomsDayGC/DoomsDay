using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSoundOnExit : MonoBehaviour {

    public static bool saveSound = false;

    public void SaveSound()
    {
        saveSound = true;
    }
}
