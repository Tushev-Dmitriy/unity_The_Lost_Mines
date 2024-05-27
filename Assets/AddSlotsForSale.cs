using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSlotsForSale : MonoBehaviour
{
    public GameObject inventorySlot;
    public GameObject saleBg;
    public GameObject inventoryBg;

    public void slotsToShop()
    {
        inventorySlot.transform.SetParent(saleBg.transform);
    }

    public void slotsToInventory()
    {
        inventorySlot.transform.SetParent(inventoryBg.transform);
    }
}
