using UnityEngine;
using System.Collections;
using TMPro;

public class Health : MonoBehaviour
{
    public int healthNum;
    public bool alive;

    public SpriteRenderer spriteRenderer;
    public float fadeDuration = 0.3f;

    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform originalSpawnPoint;
    [SerializeField] TMP_Text text;

    IEnumerator TakeDamage()
    {
        Color color = spriteRenderer.color;
        float startAlpha = 0f;
        float endAlpha = 1f;
        float elapsedTime = 0f;

        healthNum -= 1;
        Debug.Log(healthNum);
        text.text = healthNum.ToString();

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = endAlpha;
        spriteRenderer.color = color;
        yield return new WaitForSeconds(0.3f);
        gameObject.transform.position = spawnPoint.position;

        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(endAlpha, startAlpha, elapsedTime / fadeDuration);
            spriteRenderer.color = color;
            yield return null;
        }
    }
    void Update()
    {
        if (healthNum <= 0)
        {
            SetSpawn(originalSpawnPoint);
            healthNum = 5;
            text.text = healthNum.ToString();
        }
    }

    public void LoseHealth()
    {
        StartCoroutine(TakeDamage());
    }

    public void SetSpawn(Transform spawnPos) 
    { 
        spawnPoint = spawnPos;
    }
}
