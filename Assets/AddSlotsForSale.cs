using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSlotsForSale : MonoBehaviour
{
    public GameObject inventorySlot;
    public GameObject saleBg;
    public GameObject inventoryBg;

    //private Vector2 startPos = Vector2.zero;
    //private Vector2 endPos = new Vector2(270, -75);

    public void slotsToShop()
    {
        inventorySlot.transform.SetParent(saleBg.transform);
    }

    public void slotsToInventory()
    {
        inventorySlot.transform.SetParent(inventoryBg.transform);
    }
}
