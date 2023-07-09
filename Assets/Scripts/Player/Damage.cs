using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyHealth>())
        {
            EnemyHealth eH = collision.gameObject.GetComponent<EnemyHealth>();
            eH.TakeDamage(damage);
        }
    }
}
