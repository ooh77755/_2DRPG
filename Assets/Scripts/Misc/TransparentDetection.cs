using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparentDetection : MonoBehaviour
{
    [Range(0,1)]
    [SerializeField] float transpAmount = 0.8f;
    [SerializeField] float transpFadeTime = 0.4f;

    SpriteRenderer sR;
    Tilemap tM;

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
        tM = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(sR)
            {
                StartCoroutine(FadeRoutine(sR, transpFadeTime, sR.color.a, transpAmount));
            }
            else if(tM)
            {
                StartCoroutine(FadeRoutine(tM, transpFadeTime, tM.color.a, transpAmount));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(sR)
            {
                StartCoroutine(FadeRoutine(sR, transpFadeTime, sR.color.a, 1));
            }
            else if(tM)
            {
                StartCoroutine(FadeRoutine(tM, transpFadeTime, tM.color.a, 1));
            }
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

    IEnumerator FadeRoutine(Tilemap tM, float fadeTime, float StartVal, float targetTransp)
    {
        float elapsedTime = 0;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;

            float newAlpha = Mathf.Lerp(StartVal, targetTransp, elapsedTime / fadeTime);
            tM.color = new Color(tM.color.r, tM.color.g, tM.color.b, newAlpha);

            yield return null;
        }
    }
}
