using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    private float fadeSpeed = 1.1f;

    public void FadeToWhite()
    {
        fadeImage.gameObject.SetActive(true);
        StartCoroutine(Fade(1f, fadeSpeed*2.5f));
    }

    public IEnumerator FadeFromWhite()
    {

        yield return StartCoroutine(Fade(0f, fadeSpeed*2.5f));
        fadeImage.gameObject.SetActive(false);
    }

    private IEnumerator Fade(float targetAlpha, float speed)
    {
        float alpha = fadeImage.color.a;
        while (!Mathf.Approximately(alpha, targetAlpha))
        {
            alpha = Mathf.MoveTowards(alpha, targetAlpha, speed * Time.deltaTime);
            fadeImage.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
    }
}
