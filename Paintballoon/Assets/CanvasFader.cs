using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFader : MonoBehaviour
{
    public float fadeDuration = 1f;
    private CanvasGroup canvasGroup;
    private bool isFading = false;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeCanvas()
    {
        if (isFading) return;

        StartCoroutine(FadeCanvasCoroutine());
    }

    private IEnumerator FadeCanvasCoroutine()
    {
        isFading = true;

        float elapsedTime = 0f;
        float startAlpha = canvasGroup.alpha;
        float targetAlpha = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            canvasGroup.alpha = alpha;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
        isFading = false;
    }
}
