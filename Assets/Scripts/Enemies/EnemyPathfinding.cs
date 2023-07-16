using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private Rigidbody2D rB;
    private Vector2 moveDir;
    private KnockBack knockback;

    private void Awake()
    {
        knockback = GetComponent<KnockBack>();
        rB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(knockback.gettingKnockedBack == true)
        {
            return;
        }

        rB.MovePosition(rB.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPos)
    {
        moveDir = targetPos;
    }
}
