using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] Material flashMat;
    [SerializeField] float restoreDefaultMatTime = .2f;
    Material defaultMat;

    void Awake()
    {
        defaultMat = GetComponent<SpriteRenderer>().material;
    }

    public IEnumerator FlashRoutine()
    {
        GetComponent<SpriteRenderer>().material = flashMat;
        yield return new WaitForSeconds(restoreDefaultMatTime);
        GetComponent<SpriteRenderer>().material = defaultMat;
    }
}
