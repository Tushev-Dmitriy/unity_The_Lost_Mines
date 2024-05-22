using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems : MonoBehaviour
{
    public ScriptableObject[] shopItems;
    public InventorySlot[] inventorySlots;
    public StatsController statsController;

    //private void AddItemsInShop()
    //{
    //    for (int i = 0; i < inventorySlots.Length; i++)
    //    {
    //        if (inventorySlots[i].transform.childCount != 0)
    //        {
    //            GameObject currentShopSlot = inventorySlots[i].transform.GetChild(0).gameObject;
    //            if (!currentShopSlot.transform.GetChild(0).gameObject.activeSelf)
    //            {
    //                inventorySlots[i].
    //            } else
    //            {

    //            }
    //        }
    //    }
    //}
}
