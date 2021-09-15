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

    private EnemyAnimation enemyAnimation;
    private Vector3 respawnPoint = new Vector3(6.7f, -4.24f, -4.24f);
    private NavMeshAgent agent;
    private bool IsDirty = false;
    private bool IsMove = false;


    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    void Update()
    {
        if (IsMove == false) return;
        ContinueWalk();
        ChangeZPositionOnScene();
    }

    public void Restart()
    {
        transform.position = respawnPoint;
        IsMove = true;
        StartWalk();
    }

    public void RunToEatenFood()
    {
        if (IsDirty) return;
        StopMove();
        SetPlayerTargetPoint();
        IncreaseSpeed();
        StartMove();
    }

    public void Dirty()
    {
        StopMove();
        SetNormalSpeed();
        SetIsDirty(true);
        Invoke("Clean", timeToClean);

    }
    public void StopMove()
    {
        agent.isStopped = true;
        agent.ResetPath();
        IsMove = false;
    }

    private void StartMove()
    {
        agent.isStopped = false;
        IsMove = true;
    }
    void SetPlayerTargetPoint()
    {
        agent.SetDestination(targetPlayer.position);
    }

    void StartWalk()
    {
        SetTargetPoint(GetRandomPositionToMove());
    }

    void ContinueWalk()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            SetNormalSpeed();
            SetTargetPoint(GetRandomPositionToMove());
        }
    }

    void IncreaseSpeed()
    {
        agent.speed = speedEnemy * increaseSpeedBy;
    }

    void SetNormalSpeed()
    {
        agent.speed = speedEnemy;
    }

    void Clean()
    {
        SetIsDirty(false);
        // if (IsMove == false) return;
        StartMove();
        StartWalk();
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

    void ChangeZPositionOnScene()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    void SetIsDirty(bool dirty)
    {
        IsDirty = dirty;
        enemyAnimation.SetIsDirty(dirty);
    }
}
