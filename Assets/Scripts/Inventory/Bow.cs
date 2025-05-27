using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    public void Attack()
    {
        print("bow");
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }
}
