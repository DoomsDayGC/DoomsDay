using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityWarning : MonoBehaviour {

    public float FadeRate;

    private GameObject redWarning;
    private Image image;
    private float targetAlpha;

    // Use this for initialization
    void Start ()
    {
        redWarning = GameObject.Find("RedWarning");
        image = redWarning.GetComponent<Image>();

        Material instantiatedMaterial = Instantiate<Material>(this.image.material);
        this.image.material = instantiatedMaterial;
        targetAlpha = image.color.a;

        //redWarning.SetActive(true);
        FadeOut();
        var color = image.material.color;
        color.a = Mathf.Lerp(color.a, targetAlpha, 50);
        image.material.color = color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //redWarning.SetActive(false);
        Color color = image.material.color;
        
        float alphaDiff = Mathf.Abs(color.a - targetAlpha);
        if (alphaDiff > 0.0001f)
        {
            color.a = Mathf.Lerp(color.a, targetAlpha, FadeRate * Time.deltaTime);
            image.material.color = color;
        }
    }

    public void FadeOut()
    {
        targetAlpha = 0.0f;
    }

    public void FadeIn()
    {
        targetAlpha = 1.0f;
    }
}
