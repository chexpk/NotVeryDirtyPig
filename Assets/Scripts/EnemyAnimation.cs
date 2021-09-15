using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class EnemyAnimation : MonoBehaviour {
    Animator animator;
    NavMeshAgent agent;

    // Vector2 smoothDeltaPosition = Vector2.zero;
    // Vector2 velocity = Vector2.zero;

    void Start ()
    {
        animator = GetComponent<Animator> ();
        agent = GetComponent<NavMeshAgent> ();
    }

    void Update ()
    {
        animator.SetFloat ("Horizontal", GetVectorOfMovement().x);
        animator.SetFloat ("Vertical", GetVectorOfMovement().y);
        animator.SetFloat("Speed", agent.speed);
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