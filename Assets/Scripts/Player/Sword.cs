using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] GameObject slashAnimPrefab;
    [SerializeField] Transform slashAnimSpawnPoint;
    [SerializeField] Transform weaponCollider;
    private PlayerControls pC;
    Animator anim;
    PlayerController playerCon;
    GameObject slashAnim;
    float cooldown = 0.5f;
    bool attackBtnDown, isAttacking = false;

    private void Awake()
    {
        pC = new PlayerControls();
        anim = GetComponent<Animator>();
        playerCon = GetComponentInParent<PlayerController>();
    }

    private void OnEnable()
    {
        pC.Enable();
    }

    private void Start()
    {
        pC.Combat.Attack.started += _ => StartAttacking();
        pC.Combat.Attack.canceled += _ => StopAttacking();
    }

    private void Update()
    {
        Attack();
    }

    void StartAttacking()
    {
        attackBtnDown = true;
    }

    void StopAttacking()
    {
        attackBtnDown = false;
    }

    void Attack()
    {
        if(attackBtnDown && !isAttacking)
        {
            isAttacking = true;
            anim.SetTrigger("Attack");
            weaponCollider.gameObject.SetActive(true);
            slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
            slashAnim.transform.parent = this.transform.parent;
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        isAttacking = false;
    }

    public void DoneAttackingAnim()
    {
        weaponCollider.gameObject.SetActive(false);
    }

    public void SwingUpFlipAnim()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180f, 0, 0);

        if(playerCon.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void SwingDownFlipAnim()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (playerCon.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

}
