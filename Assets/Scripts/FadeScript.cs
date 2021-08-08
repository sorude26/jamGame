using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public float fadeSpeed = 0.002F;
    float alfa;
    float red, green, blue;
    public bool isFadeout = false;
    public bool isFadein = false;

    [SerializeField] Image fadeImage;
    private void Awake()
    {
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    public void StartFadeout(Action FadeOutEvent)
    {
        StartCoroutine(FadeOutStart(FadeOutEvent));
    }

    public void StartFadeIn(Action FadeInEvent)
    {
        StartCoroutine(FadeInStart(FadeInEvent));
    }
    IEnumerator FadeOutStart(Action FadeOutEvent)
    {
        isFadeout = true;
        while (isFadeout)
        {
            FadeOut();
            yield return new WaitForEndOfFrame();
        }
        FadeOutEvent?.Invoke();
    }
    IEnumerator FadeInStart(Action FadeInEvent)
    {
        isFadein = true;
        while (isFadein)
        {
            FadeIn();
            yield return new WaitForEndOfFrame();
        }
        FadeInEvent?.Invoke();
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
