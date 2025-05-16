using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    float waitToLoad = 1f;
    bool canTransition = false;

    private void Start()
    {
        StartCoroutine(EnableTransition());
    }

    IEnumerator EnableTransition()
    {
        yield return new WaitForSeconds(0.5f);
        canTransition = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canTransition) return;
        
        if(collision.gameObject.tag == "Player")
        {
            SceneManagement.Instance.SetTransitionName(sceneTransitionName);
            StartCoroutine(FadeAndLoad());
        }
    }

    IEnumerator FadeAndLoad()
    {
        UIFade.Instance.FadeToBlack();
        yield return new WaitForSeconds(1);
        StartCoroutine(LoadSceneRoutine());
    }

    IEnumerator LoadSceneRoutine()
    {
        while(waitToLoad >= 0)
        {
            waitToLoad -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
