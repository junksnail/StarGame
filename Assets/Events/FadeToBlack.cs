using UnityEngine;
using System.Collections;

public class FadeToBlack : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float fadeDuration = 2f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Color color = spriteRenderer.color;
        float startAlpha = 0f;
        float endAlpha = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = endAlpha;
        spriteRenderer.color = color;
    }
}