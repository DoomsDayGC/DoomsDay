using UnityEngine;
using System.Collections;

public class DemoGUI : MonoBehaviour {

	public GameObject[] Prefabs;

	private int currentNomber;
	private GameObject currentInstance;
	private GUIStyle guiStyleHeader = new GUIStyle();
	// Use this for initialization
	void Start () {
		guiStyleHeader.fontSize = 15;
		guiStyleHeader.normal.textColor = new Color(1,1,1);
		currentInstance = Instantiate(Prefabs[currentNomber], transform.position, Prefabs[currentNomber].transform.rotation) as GameObject;
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(10, 15, 105, 30), "Previous Effect")) {
			ChangeCurrent(-1);
		}
		if (GUI.Button(new Rect(130, 15, 105, 30), "Next Effect"))
		{
			ChangeCurrent(+1);
		}
		GUI.Label(new Rect(300, 15, 100, 20), "Prefab name is \"" + Prefabs[currentNomber].name + "\"  \r\nHold any mouse button that would move the camera", guiStyleHeader);
	}
	// Update is called once per frame
	void ChangeCurrent(int delta) {
		currentNomber+=delta;
		if (currentNomber> Prefabs.Length - 1)
			currentNomber = 0;
		else if (currentNomber < 0)
			currentNomber = Prefabs.Length - 1;
		if(currentInstance!=null) Destroy(currentInstance.transform.root.gameObject);
		currentInstance = Instantiate(Prefabs[currentNomber], transform.position, Prefabs[currentNomber].transform.rotation) as GameObject;
	}
}
