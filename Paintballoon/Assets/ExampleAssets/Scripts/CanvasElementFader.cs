using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasElementFader : MonoBehaviour
{
    public float fadeDuration = 1f;

    private bool isFading = false;

    public CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup.alpha = 0;
    }
    

    public void FadeElements()
    {
        if (isFading) return;

        StartCoroutine(FadeElementsCoroutine());
    }

    private IEnumerator FadeElementsCoroutine()
    {
        isFading = true;

        float elapsedTime = 0f;
      

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            canvasGroup.alpha = 1 - t;

            yield return null;
        }


        isFading = false;
        yield break;
    }
    public void ResetElements()
    {
        canvasGroup.alpha = 1;
    }
}