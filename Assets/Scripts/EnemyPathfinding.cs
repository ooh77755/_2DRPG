using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    EnemyAI enemyAI;
    Rigidbody2D rB;

    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        rB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 roamPos = enemyAI.GetRoamingPos();

        rB.MovePosition(rB.position + roamPos * (moveSpeed * Time.fixedDeltaTime));
    }
}
