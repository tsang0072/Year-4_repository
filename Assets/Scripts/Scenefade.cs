using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenefade : MonoBehaviour
{
    Image fadeImage;
    void Start()
    {
        fadeImage = GetComponent<Image>();
    }

  
    public IEnumerator FadeInCoroutine(float duration)
    {
        
        Color startcolor=new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
        Color stargetColor=new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);

        yield return FadeCoroutine(startcolor, stargetColor, duration);
        fadeImage.gameObject.SetActive(false);
    }
    public IEnumerator FadeOutCoroutine(float duration)
    {
        Color startcolor=new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
        Color stargetColor=new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);

        fadeImage.gameObject.SetActive(true);
        yield return FadeCoroutine(startcolor, stargetColor, duration);
    }
    private IEnumerator FadeCoroutine(Color startColor, Color targetColor, float duration)
    {
        float elapsedTime=0;
        float elapsedPercentage=0;

        while (elapsedPercentage < 1)
        {
            elapsedPercentage=elapsedTime/duration;
            fadeImage.color=Color.Lerp(startColor, targetColor,elapsedPercentage);
            
            yield return null;
            elapsedTime+=Time.deltaTime;
        }
    }
}
