using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentDetection : MonoBehaviour
{
    [Range(0,1)]
    [SerializeField] float transpAmount = 0.8f;
    [SerializeField] float transpFadeTime = 0.4f;

    SpriteRenderer sR;

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(FadeRoutine(sR, transpAmount, transpFadeTime, sR.color.a));
        }
    }

    IEnumerator FadeRoutine(SpriteRenderer sR, float fadeTime, float StartVal, float targetTransp)
    {
        float elapsedTime = 0;
        while(elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(StartVal, targetTransp, elapsedTime / fadeTime);
            sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, newAlpha);
            yield return null;
        }
    }
}
