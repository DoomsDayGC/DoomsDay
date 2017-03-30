using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityWarning : MonoBehaviour
{
    public float FadeRate;

    private GameObject redWarning;
    private Image redImage;
    private GameObject orangeWarning;
    private Image orangeImage;
    private GameObject yellowWarning;
    private Image yellowImage;
    private GameObject blueWarning;
    private Image blueImage;

    private float targetAlphaRed;
    private float targetAlphaOrange;
    private float targetAlphaYellow;
    private float targetAlphaBlue;

    // Use this for initialization
    void Start ()
    {
        redWarning = GameObject.Find("RedWarning");
        redImage = redWarning.GetComponent<Image>();

        orangeWarning = GameObject.Find("OrangeWarning");
        orangeImage = orangeWarning.GetComponent<Image>();

        yellowWarning = GameObject.Find("YellowWarning");
        yellowImage = yellowWarning.GetComponent<Image>();

        blueWarning = GameObject.Find("BlueWarning");
        blueImage = blueWarning.GetComponent<Image>();

        //// Red
        Material instantiatedMaterialRed = Instantiate<Material>(this.redImage.material);
        this.redImage.material = instantiatedMaterialRed;
        targetAlphaRed = redImage.color.a;

        FadeOutRed();
        var colorRed = redImage.material.color;
        colorRed.a = Mathf.Lerp(colorRed.a, targetAlphaRed, 50);
        redImage.material.color = colorRed;

        //// Orange
        Material instantiatedMaterialOrange = Instantiate<Material>(this.orangeImage.material);
        this.orangeImage.material = instantiatedMaterialOrange;
        targetAlphaOrange = orangeImage.color.a;

        FadeOutOrange();
        var colorOrange = orangeImage.material.color;
        colorOrange.a = Mathf.Lerp(colorOrange.a, targetAlphaOrange, 50);
        orangeImage.material.color = colorOrange;

        ///// Yellow
        Material instantiatedMaterialYellow = Instantiate<Material>(this.yellowImage.material);
        this.yellowImage.material = instantiatedMaterialYellow;
        targetAlphaYellow = yellowImage.color.a;

        FadeOutYellow();
        var colorYellow = yellowImage.material.color;
        colorYellow.a = Mathf.Lerp(colorYellow.a, targetAlphaYellow, 50);
        yellowImage.material.color = colorYellow;

        ///// Blue
        Material instantiatedMaterialBlue = Instantiate<Material>(this.blueImage.material);
        this.blueImage.material = instantiatedMaterialBlue;
        targetAlphaBlue = blueImage.color.a;

        FadeOutBlue();
        var colorBlue = blueImage.material.color;
        colorBlue.a = Mathf.Lerp(colorBlue.a, targetAlphaBlue, 50);
        blueImage.material.color = colorBlue;
    }

    // Update is called once per frame
    void Update()
    {
        Color redColor = redImage.material.color;
        Color orangeColor = orangeImage.material.color;
        Color yellowColor = yellowImage.material.color;
        Color blueColor = blueImage.material.color;

        float alphaDiffYellow = Mathf.Abs(yellowColor.a - targetAlphaYellow);
        if (alphaDiffYellow > 0.0001f)
        {
            yellowColor.a = Mathf.Lerp(yellowColor.a, targetAlphaYellow, FadeRate * Time.deltaTime);
            yellowImage.material.color = yellowColor;
        }

        float alphaDiffOrange = Mathf.Abs(orangeColor.a - targetAlphaOrange);
        if (alphaDiffOrange > 0.0001f)
        {
            orangeColor.a = Mathf.Lerp(orangeColor.a, targetAlphaOrange, FadeRate * Time.deltaTime);
            orangeImage.material.color = orangeColor;
        }

        float alphaDiffRed = Mathf.Abs(redColor.a - targetAlphaRed);
        if (alphaDiffRed > 0.0001f)
        {
            redColor.a = Mathf.Lerp(redColor.a, targetAlphaRed, FadeRate * Time.deltaTime);
            redImage.material.color = redColor;
        }

        float alphaDiffBlue = Mathf.Abs(blueColor.a - targetAlphaBlue);
        if (alphaDiffBlue > 0.0001f)
        {
            blueColor.a = Mathf.Lerp(blueColor.a, targetAlphaBlue, FadeRate * Time.deltaTime);
            blueImage.material.color = blueColor;
        }
    }

    // Red
    public void FadeOutRed()
    {
        targetAlphaRed = 0.0f;
    }

    public void FadeInRed()
    {
        targetAlphaRed = 2.0f;
    }

    // Orange
    public void FadeOutOrange()
    {
        targetAlphaOrange = 0.0f;
    }

    public void FadeInOrange()
    {
        targetAlphaOrange = 3.0f;
    }

    // Yellow
    public void FadeOutYellow()
    {
        targetAlphaYellow = 0.0f;
    }

    public void FadeInYellow()
    {
        targetAlphaYellow = 3.0f;
    }

    // Blue
    public void FadeOutBlue()
    {
        targetAlphaBlue = 0.0f;
    }

    public void FadeInBlue()
    {
        targetAlphaBlue = 1.5f;
    }
}
