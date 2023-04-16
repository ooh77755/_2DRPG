using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] GameObject slashAnimPrefab;
    [SerializeField] Transform slashAnimSpawnPoint;
    private PlayerControls pC;
    Animator anim;
    PlayerController playerCon;

    GameObject slashAnim;

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
        pC.Combat.Attack.started += _ => Attack();
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
    }

    public void SwingUpFlipAnim()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180f, 0, 0);

        if(playerCon.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
        
    }

}
