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
    }
}
