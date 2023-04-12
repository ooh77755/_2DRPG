using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    PlayerControls pC;
    Vector2 movement;
    Rigidbody2D rB;
    Animator anim;

    private void Awake()
    {
        pC = new PlayerControls();
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        pC.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerDirection();
        Move();
    }

    void PlayerInput()
    {
        movement = pC.Movement.Move.ReadValue<Vector2>();
        anim.SetFloat("moveX", movement.x);
        anim.SetFloat("moveY", movement.y);
    }

    void Move()
    {
        rB.MovePosition(rB.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    void AdjustPlayerDirection()
    {

    }
}
