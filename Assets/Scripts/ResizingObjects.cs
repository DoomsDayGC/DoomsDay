using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizingObjects : MonoBehaviour
{
    // The player
    public GameObject Player;

    // Prefabs
    public List<GameObject> Prefabs = new List<GameObject>();

    // Player's scale the other planets will scale from
    private float playerScale;

    private void Start()
    {
        playerScale = Player.transform.position.x;
    }

    void Update ()
    {
	    foreach(var obj in Prefabs)
        {
            if(obj.tag == "Mercury")
            {
                float dim = 38 / 100.0f * playerScale * 5;
                obj.transform.localScale = new Vector3(dim,dim,dim);
            }

            if (obj.tag == "Mars")
            {
                float dim = 53 / 100.0f * playerScale * 4;
                obj.transform.localScale = new Vector3(dim, dim, dim);
            }

            if (obj.tag == "Venus")
            {
                float dim = 95 / 100.0f * playerScale * 3;
                obj.transform.localScale = new Vector3(dim, dim, dim);
            }

            if (obj.tag == "Neptune")
            {
                float dim = 388 / 100.0f * playerScale;
                obj.transform.localScale = new Vector3(dim, dim, dim);
            }

            if (obj.tag == "Saturn")
            {
                float dim = 945 / 100.0f * playerScale;
                obj.transform.localScale = new Vector3(dim, dim, dim);
            }

            if (obj.tag == "Jupiter")
            {
                float dim = 1120 / 100.0f * playerScale;
                obj.transform.localScale = new Vector3(dim, dim, dim);
            }
        }	
	}
}
