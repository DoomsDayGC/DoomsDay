using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager GM;

    public KeyCode forwardFP { get; set; }
    public KeyCode backwardFP { get; set; }
    public KeyCode leftFP { get; set; }
    public KeyCode rightFP { get; set; }

    public KeyCode forwardSP { get; set; }
    public KeyCode backwardSP { get; set; }
    public KeyCode leftSP { get; set; }
    public KeyCode rightSP { get; set; }

    public KeyCode useItem1 { get; set; }
    public KeyCode useItem2 { get; set; }
    public KeyCode useItem3 { get; set; }

    public KeyCode useItemSP { get; set; }

    public KeyCode pause { get; set; }

    private void Awake()
    {
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }

        forwardFP = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardFPKey", "UpArrow"));
        backwardFP = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardFPKey", "DownArrow"));
        leftFP = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftFPKey", "LeftArrow"));
        rightFP = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightFPKey", "RightArrow"));

        forwardSP = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardSPKey", "W"));
        backwardSP = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardSPKey", "S"));
        leftSP = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftSPKey", "A"));
        rightSP = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightSPKey", "D"));

        useItem1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("useItem1Key", "Comma"));
        useItem2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("useItem2Key", "Period"));
        useItem3 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("useItem3Key", "Slash"));
        useItemSP = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("useItemSPKey", "LeftAlt"));

        pause = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pauseKey", "Escape"));
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
