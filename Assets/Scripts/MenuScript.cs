using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    Transform menuPanel; // used to open up the menu by pressing the pause button
    Event KeyEvent; // used to detec what key is the user pressing
    Text buttonText; // The text component of the button
    KeyCode newKey;

    bool waitingForKey;

    bool saved = false; // Check if the settings were saved or not
                        // If they are not saved after changes were made, the back button turns into Cancel

    // Use this for initialization
    void Start()
    {
        menuPanel = transform.FindChild("ControlSettingsPanel"); // Looks through the objects of the Canvas and finds the Panel
        menuPanel.gameObject.SetActive(false); // At the start the game panel won't be showed
        waitingForKey = false;

        for (int i = 0; i < 16; i++)
        {
            if (menuPanel.GetChild(i).name == "upwardFPKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.upwardFP.ToString();
            else if (menuPanel.GetChild(i).name == "downwardFPKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.downwardFP.ToString();
            else if (menuPanel.GetChild(i).name == "leftFPKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.leftFP.ToString();
            else if (menuPanel.GetChild(i).name == "rightFPKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.rightFP.ToString();
            else if (menuPanel.GetChild(i).name == "upwardSPKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.upwardSP.ToString();
            else if (menuPanel.GetChild(i).name == "downwardSPKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.downwardSP.ToString();
            else if (menuPanel.GetChild(i).name == "leftSPKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.leftSP.ToString();
            else if (menuPanel.GetChild(i).name == "rightSPKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.rightSP.ToString();
            else if (menuPanel.GetChild(i).name == "useItem1Key")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.useItem1.ToString();
            else if (menuPanel.GetChild(i).name == "useItem2Key")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.useItem2.ToString();
            else if (menuPanel.GetChild(i).name == "useItem3Key")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.useItem3.ToString();
            else if (menuPanel.GetChild(i).name == "useItemSPKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.useItemSP.ToString();
            else if (menuPanel.GetChild(i).name == "pauseKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.pause.ToString();
            else if (menuPanel.GetChild(i).name == "saveButton")
            {
                // Trying to change the Back button text to Cancel when is the case
                saved = true;
                for (int j = 0; j < 16; j++)
                    if (menuPanel.GetChild(j).name == "returnButton" && !saved)
                        menuPanel.GetChild(j).GetComponentInChildren<Text>().text = "Cancel";
                    else if (menuPanel.GetChild(j).name == "returnButton" && saved)
                        menuPanel.GetChild(j).GetComponentInChildren<Text>().text = "Back";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf)
            menuPanel.gameObject.SetActive(true);
        else if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
            menuPanel.gameObject.SetActive(false);
            */
    }

    private void OnGUI()
    {
        KeyEvent = Event.current; // 2) declared here detects that the user is pressing a key

        if (KeyEvent.isKey && waitingForKey)
        {
            newKey = KeyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText(Text text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKey()
    {
        while (!KeyEvent.isKey) // 1) until our user is pressing a key
            yield return null; // Basically an infinite loop until the KeyEvent 2)
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return WaitForKey(); // Stops the coroutine from executing until 1)

        switch (keyName)
        {
            case "upwardFP":
                GameManager.GM.upwardFP = newKey;
                buttonText.text = GameManager.GM.upwardFP.ToString();
                PlayerPrefs.SetString("upwardFPKey", GameManager.GM.upwardFP.ToString());
                break;
            case "downwardFP":
                GameManager.GM.downwardFP = newKey;
                buttonText.text = GameManager.GM.downwardFP.ToString();
                PlayerPrefs.SetString("downwardFPKey", GameManager.GM.downwardFP.ToString());
                break;
            case "leftFP":
                GameManager.GM.leftFP = newKey;
                buttonText.text = GameManager.GM.leftFP.ToString();
                PlayerPrefs.SetString("leftFPKey", GameManager.GM.leftFP.ToString());
                break;
            case "rightFP":
                GameManager.GM.rightFP = newKey;
                buttonText.text = GameManager.GM.rightFP.ToString();
                PlayerPrefs.SetString("rightFPKey", GameManager.GM.rightFP.ToString());
                break;
            case "upwardSP":
                GameManager.GM.upwardSP = newKey;
                buttonText.text = GameManager.GM.upwardSP.ToString();
                PlayerPrefs.SetString("upwardSPKey", GameManager.GM.upwardSP.ToString());
                break;
            case "downwardSP":
                GameManager.GM.downwardSP = newKey;
                buttonText.text = GameManager.GM.downwardSP.ToString();
                PlayerPrefs.SetString("downwardSPKey", GameManager.GM.downwardSP.ToString());
                break;
            case "leftSP":
                GameManager.GM.leftSP = newKey;
                buttonText.text = GameManager.GM.leftSP.ToString();
                PlayerPrefs.SetString("leftSPKey", GameManager.GM.leftSP.ToString());
                break;
            case "rightSP":
                GameManager.GM.rightSP = newKey;
                buttonText.text = GameManager.GM.rightSP.ToString();
                PlayerPrefs.SetString("rightSPKey", GameManager.GM.rightSP.ToString());
                break;
            case "useItem1":
                GameManager.GM.useItem1 = newKey;
                buttonText.text = GameManager.GM.useItem1.ToString();
                PlayerPrefs.SetString("useItem1Key", GameManager.GM.useItem1.ToString());
                break;
            case "useItem2":
                GameManager.GM.useItem2 = newKey;
                buttonText.text = GameManager.GM.useItem2.ToString();
                PlayerPrefs.SetString("useItem2Key", GameManager.GM.useItem2.ToString());
                break;
            case "useItem3":
                GameManager.GM.useItem3 = newKey;
                buttonText.text = GameManager.GM.useItem3.ToString();
                PlayerPrefs.SetString("useItem3Key", GameManager.GM.useItem3.ToString());
                break;
            case "useItemSP":
                GameManager.GM.useItemSP = newKey;
                buttonText.text = GameManager.GM.useItemSP.ToString();
                PlayerPrefs.SetString("useItemSPKey", GameManager.GM.useItemSP.ToString());
                break;
            case "pause":
                GameManager.GM.pause = newKey;
                buttonText.text = GameManager.GM.pause.ToString();
                PlayerPrefs.SetString("pauseKey", GameManager.GM.pause.ToString());
                break;
        }

        yield return null;
    }

}
