using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public float fadeSpeed = 0.002F;
    float alfa;
    float red, green, blue;
    public bool isFadeout = false;
    public bool isFadein = false;

    Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    public void startFadeout()
    {
        StartCoroutine(FadeOutStart());
    }

    public void startFadeIn()
    {
        StartCoroutine(FadeInStart());
    }
    IEnumerator FadeOutStart()
    {
        isFadeout = true;
        while (isFadeout)
        {
            FadeOut();
            yield return new WaitForEndOfFrame();
        }

    }
    IEnumerator FadeInStart()
    {
        isFadein = true;
        while (isFadein)
        {
            FadeIn();
            yield return new WaitForEndOfFrame();
        }
    }
    void FadeIn()
    {
        alfa -= fadeSpeed;
        SetAlpha();
        if(alfa <= 0)
        {
            isFadein = false;
            fadeImage.enabled = false;
        }

    }

    void FadeOut()
    {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlpha();
        if (alfa >= 1)
        {
            isFadeout = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
