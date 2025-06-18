using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : MonoBehaviour
{
    int activeSlotIndex = 0;

    PlayerControls pC;

    private void Awake()
    {
        pC = new PlayerControls();
    }

    private void Start()
    {
        pC.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
        
        //spawns sword on game start
        ToggleActiveHighlight(0);
    }

    private void OnEnable()
    {
        pC.Enable();
    }

    void ToggleActiveSlot(int numValue)
    {
        ToggleActiveHighlight(numValue);
    }

    void ToggleActiveHighlight(int indexNum)
    {
        activeSlotIndex = indexNum;

        foreach(Transform iSlot in this.transform)
        {
            iSlot.GetChild(0).gameObject.SetActive(false);
        }

        this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);
        ChangeActiveWeapon();
    }

    void ChangeActiveWeapon()
    {
        //deletes instantiated activeWeapon IF same instantiated weapon is already there
        //i.e. so it won't spawn in a sword to the scene IF a bow is already there
        //it swaps instantiates each new weapon & destroys old weapon simultaneously
        if(ActiveWeapon.Instance.CurrentActiveWeapon != null)
        {
            Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject);
        }

        if(!transform.GetChild(activeSlotIndex).GetComponent<InventorySlot>())
        {
            ActiveWeapon.Instance.WeaponNull();
            return;
        }

        GameObject weaponToSpawn = transform.GetChild(activeSlotIndex).GetComponentInChildren<InventorySlot>().GetWeaponInfo().weaponPrefab;
        GameObject newWapon = Instantiate(weaponToSpawn, ActiveWeapon.Instance.transform.position, Quaternion.identity);

        //makes a child of ActiveWeapon GaOb in heirarchy
        newWapon.transform.parent = ActiveWeapon.Instance.transform;

        ActiveWeapon.Instance.NewWeapon(newWapon.GetComponent<MonoBehaviour>());
    }
}
