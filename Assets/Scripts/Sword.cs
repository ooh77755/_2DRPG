using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerControls pC;
    Animator anim;

    private void Awake()
    {
        pC = new PlayerControls();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        pC.Enable();
    }

    private void Start()
    {
        pC.Combat.Attack.started += _ => Attack();
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }

}
