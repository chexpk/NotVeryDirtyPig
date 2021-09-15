using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private Transform[] movementPositions;
    private NavMeshAgent agent;
    private bool IsAngry = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    public void SetNewTargetPoint()
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
        if(IsAngry == true) return;

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            SetTargetPoint(GetRandomPositionToMove());
        }
    }
}
