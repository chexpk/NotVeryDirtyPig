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
    [SerializeField] private float timeToClean = 3f;

    private NavMeshAgent agent;
    private bool IsAngry = false;
    private bool IsDirty = false;
    private bool IsMove = true;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        StartWalk();
    }

    void Update()
    {
        if (IsMove == false) return;
        ContinueWalk();
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

    void StartWalk()
    {
        SetTargetPoint(GetRandomPositionToMove());
    }

    void ContinueWalk()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            IsAngry = false;
            SetNormalSpeed();
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
        StopMove();
        SetPlayerTargetPoint();
        IncreaseSpeed();
        StartMove();
    }

    private void StartMove()
    {
        agent.isStopped = false;
        IsMove = true;
    }

    void IncreaseSpeed()
    {
        agent.speed = speedEnemy * increaseSpeedBy;
    }

    void SetNormalSpeed()
    {
        agent.speed = speedEnemy;
    }

    public void Dirty()
    {
        Debug.Log("dirty");
        IsAngry = false;
        StopMove();
        SetNormalSpeed();
        IsDirty = true;
        Invoke("Clean", timeToClean);
    }

    void Clean()
    {
        IsAngry = false;
        StartWalk();
    }

    void StopMove()
    {
        agent.isStopped = true;
        agent.ResetPath();
        IsMove = false;
    }
}
