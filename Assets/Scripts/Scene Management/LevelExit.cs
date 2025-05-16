using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;

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
            SceneManager.LoadScene(sceneToLoad);
            SceneManagement.Instance.SetTransitionName(sceneTransitionName);
        }
    }

    
}
