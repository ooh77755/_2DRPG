using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    public static PlayerController Instance;

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float dashSpeed = 5f;
    [SerializeField] float dashDuration = 0.2f;
    [SerializeField] float dashCooldown = 1f;

    PlayerControls pC;
    Vector2 movement;
    Rigidbody2D rB;
    Animator anim;
    [SerializeField] ParticleSystem dashVFX;

    bool facingLeft = false;
    bool isDashing = false;
    bool canDash = true;
    float dashTime;
    float dashCooldownTime;

    private void Awake()
    {
        Instance = this;
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
        HandleDash();
    }

    private void FixedUpdate()
    {
        AdjustPlayerDirection();
        if(!isDashing)
        {
            Move();
        }

    }

    void PlayerInput()
    {
        movement = pC.Movement.Move.ReadValue<Vector2>();
        anim.SetFloat("moveX", movement.x);
        anim.SetFloat("moveY", movement.y);

        if (pC.Movement.Dash.triggered && canDash)
        {
            StartDash();
        }
    }

    void Move()
    {
        rB.MovePosition(rB.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    void AdjustPlayerDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if(mousePos.x < playerScreenPoint.x)
        {
            transform.localScale = new Vector2(-1f, 1f);
            FacingLeft = true;
        }
        else
        {
            transform.localScale = new Vector2(1f, 1f);
            FacingLeft = false;
        }
    }

    void StartDash()
    {
        dashVFX.Play();
        isDashing = true;
        canDash = false;
        dashTime = Time.time + dashDuration;  
        dashCooldownTime = Time.time + dashCooldown;
        rB.velocity = new Vector2(movement.x * dashSpeed, movement.y * dashSpeed);
    }

    void HandleDash()
    {
        if (isDashing)
        {
            if (Time.time >= dashTime)
            {
                isDashing = false;
                dashVFX.Stop();
                rB.velocity = Vector2.zero;  
            }
        }


        if (!canDash && Time.time >= dashCooldownTime)
        {
            canDash = true;
        }
    }
}
