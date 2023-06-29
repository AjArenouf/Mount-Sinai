using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasElementFader : MonoBehaviour
{
    public float fadeDuration = 1f;

    public Image imageToFade;
    public Button buttonToFade;

    private bool isFading = false;

   public void FadeElements()
    {
        if (isFading) return;

        StartCoroutine(FadeElementsCoroutine());
    }               

    private IEnumerator FadeElementsCoroutine()
    {
        isFading = true;

        float elapsedTime = 0f;
        Color startColor = imageToFade.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            imageToFade.color = Color.Lerp(startColor, targetColor, t);
            buttonToFade.image.color = Color.Lerp(startColor, targetColor, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageToFade.color = targetColor;
        buttonToFade.image.color = targetColor;

        isFading = false;
    }
}