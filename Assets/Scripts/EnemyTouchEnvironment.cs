using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchEnvironment : MonoBehaviour
{
    [SerializeField] private EnemyAI enemyAI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Explosion>())
        {
            enemyAI.Dirty();
        }
        if (!other.GetComponent<Player>()) return;
        other.GetComponent<Player>().WasCatched();
        enemyAI.StopMove();
    }
}
