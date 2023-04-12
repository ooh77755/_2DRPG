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

    private void Awake()
    {
        pC = new PlayerControls();
        rB = GetComponent<Rigidbody2D>();
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
        Move();
    }

    void PlayerInput()
    {
        movement = pC.Movement.Move.ReadValue<Vector2>();
    }

    void Move()
    {
        rB.MovePosition(rB.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
}
