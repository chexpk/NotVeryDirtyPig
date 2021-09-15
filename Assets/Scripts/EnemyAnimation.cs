using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    private bool IsDirty = false;

    void Start ()
    {
        animator = GetComponent<Animator> ();
        agent = GetComponent<NavMeshAgent> ();
    }

    void Update ()
    {
        animator.SetBool("Dirty", IsDirty);
        animator.SetFloat ("Horizontal", GetVectorOfMovement().x);
        animator.SetFloat ("Vertical", GetVectorOfMovement().y);
        animator.SetFloat("Speed", agent.speed);
    }

    public void SetIsDirty(bool dirty)
    {
        IsDirty = dirty;
    }
    Vector2 GetVectorOfMovement()
    {
        var vector = agent.desiredVelocity;
        float x = Mathf.Clamp(vector.x, -1f, 1f);
        float y = Mathf.Clamp(vector.y, -1f, 1f);
        var result = new Vector2(x, y);
        return result;
    }
}