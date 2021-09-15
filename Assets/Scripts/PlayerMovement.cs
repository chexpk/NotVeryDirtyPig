using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Joystick joystick;

    private Vector3 spawnPoint = new Vector3(-8.4f,-0.23f, -0.23f);
    private Vector2 movement;
    private bool IsMove = true;

    void Update()
    {
        if (IsMove == false) return;
        GetInput();
        PlayAnimationOfMove();
        ChangeZPositionOnScene();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void PlayAnimationOfMove()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void GetInput()
    {
        movement.x = joystick.Horizontal;
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
        }

        movement.y = joystick.Vertical;
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            movement.y = Input.GetAxisRaw("Vertical");
        }

        movement = movement.normalized;
    }

    private void ChangeZPositionOnScene()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    public void SetIsMove(bool move)
    {
        IsMove = move;
    }

    public void PutToSpawnPosition()
    {
        transform.position = spawnPoint;
    }
}
