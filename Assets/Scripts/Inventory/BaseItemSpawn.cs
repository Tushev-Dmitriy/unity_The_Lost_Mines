using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItemSpawn : MonoBehaviour
{
    public InventoryScript inventoryScript;
    private void Start()
    {
        inventoryScript.PickupItem(0, 0);
        inventoryScript.PickupItem(1, 0);
        inventoryScript.PickupItem(2, 0);
        inventoryScript.PickupItem(4, 0);
        for (int i = 0; i < 5; i++)
        {
            inventoryScript.PickupItem(0, 1);
        }
    }
}
