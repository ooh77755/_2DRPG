using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    [SerializeField] GameObject slashAnimPrefab;
    [SerializeField] Transform slashAnimSpawnPoint;
    [SerializeField] Transform weaponCollider;

    Animator anim;
    PlayerController playerCon;
    GameObject slashAnim;
    float cooldown = 0.5f;


    private void Awake()
    {

        anim = GetComponent<Animator>();
        playerCon = GetComponentInParent<PlayerController>();
    }

    public void Attack()
    {

        //isAttacking = true;
        anim.SetTrigger("Attack");
        weaponCollider.gameObject.SetActive(true);
        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
        StartCoroutine(AttackCooldown());

    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }

    public void DoneAttackingAnim()
    {
        weaponCollider.gameObject.SetActive(false);
    }

    public void SwingUpFlipAnim()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180f, 0, 0);

        if (playerCon.FacingLeft)
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