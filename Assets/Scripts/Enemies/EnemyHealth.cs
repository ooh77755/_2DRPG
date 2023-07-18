using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;
    int currentHealth;
    KnockBack knockback;
    Flash flash;

    private void Awake()
    {
        knockback = GetComponent<KnockBack>();
        flash = GetComponent<Flash>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform, 15f);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    void DetectDeath()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
