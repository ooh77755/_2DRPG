using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming
    }

    State state;
    EnemyPathfinding enemyPath;

    private void Awake()
    {
        state = State.Roaming;
        enemyPath = GetComponent<EnemyPathfinding>();
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    IEnumerator RoamingRoutine()
    {
        while(state == State.Roaming)
        {
            Vector2 roamPos = GetRoamingPos();
            print(roamPos);
            yield return new WaitForSeconds(2f);
        }
    }

    public Vector2 GetRoamingPos()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
