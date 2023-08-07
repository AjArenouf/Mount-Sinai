using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasElementFader : MonoBehaviour
{
    public float fadeDuration = 1f;
    public GameObject canvasToDeactivate;

    public Image imageToFade;
    public Button buttonToFade;
    public TextMeshProUGUI textToFade;

    private bool isFading = false;

    private Color originalImageColor;
    private Color originalButtonColor;
    private Color originalTextColor;

    private Color targetImageColor;
    private Color targetButtonColor;
    private Color targetTextColor;

    private void Start()
    {
        originalImageColor = imageToFade.color;
        originalButtonColor = buttonToFade.image.color;
        originalTextColor = textToFade.color;

        targetImageColor = new Color(originalImageColor.r, originalImageColor.g, originalImageColor.b, 0f);
        targetButtonColor = new Color(originalButtonColor.r, originalButtonColor.g, originalButtonColor.b, 0f);
        targetTextColor = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, 0f);
    }
    public void FadeElementsAndDeactivateCanvas()
    {
        if (isFading) return;

        StartCoroutine(FadeElementsCoroutineAndDeactivateCanvas());
    }

    private IEnumerator FadeElementsCoroutineAndDeactivateCanvas()
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
            textToFade.color = Color.Lerp(startColor, targetColor, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageToFade.color = targetColor;
        buttonToFade.image.color = targetColor;
        textToFade.color = targetColor;

        isFading = false;

        // Deactivate the canvas
        canvasToDeactivate.SetActive(false);
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
        Color startColor = imageToFade.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            imageToFade.color = Color.Lerp(startColor, targetColor, t);
            buttonToFade.image.color = Color.Lerp(startColor, targetColor, t);
            textToFade.color = Color.Lerp(startColor, targetColor, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageToFade.color = targetColor;
        buttonToFade.image.color = targetColor;
        textToFade.color = targetColor;

        isFading = false;
    }
    public void ResetElements()
    {
        if (isFading) return;

        StartCoroutine(RestoreElementsCoroutine());
    }

    private IEnumerator RestoreElementsCoroutine()
    {
        isFading = true;

        imageToFade.color = originalImageColor;
        buttonToFade.image.color = originalButtonColor;
        textToFade.color = originalTextColor;

        yield return new WaitForSeconds(fadeDuration);

        isFading = false;
    }
}