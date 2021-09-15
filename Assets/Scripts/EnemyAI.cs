using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private Transform[] movementPositions;

    [SerializeField] private float speedEnemy = 2.5f;

    [SerializeField] private int increaseSpeedBy = 3;
    private NavMeshAgent agent;
    private bool IsAngry = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        Walk();
        ChangeZPositionOnScene();
    }

    public void SetPlayerTargetPoint()
    {
        agent.SetDestination(targetPlayer.position);
    }

    void SetTargetPoint(Vector2 position)
    {
        agent.SetDestination(position);
    }

    Vector2 GetRandomPositionToMove()
    {
        int maxIndexOfArr = movementPositions.Length - 1;
        int randomIndex = Random.Range(0, maxIndexOfArr);
        return movementPositions[randomIndex].position;
    }

    void Walk()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            IsAngry = false;
            agent.speed = speedEnemy;
            SetTargetPoint(GetRandomPositionToMove());
        }
    }

    private void ChangeZPositionOnScene()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    public void RunToEatenFood()
    {
        IsAngry = true;
        agent.isStopped = true;
        agent.ResetPath();
        agent.isStopped = false;
        SetPlayerTargetPoint();
        agent.speed = speedEnemy * increaseSpeedBy;
    }
}
