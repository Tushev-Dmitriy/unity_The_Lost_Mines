using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public SlotChecker slotChecker;
    public StatsController statsController;

    public string nameOfItem;
    public int numOfItem;

    public void BuyItemInShop()
    {
        GameObject itemInSlot = gameObject.transform.GetChild(0).gameObject;
        if (statsController.playerLevel >= itemInSlot.GetComponent<ItemInfo>().requiredLevel &&
            statsController.playerMoney >= itemInSlot.GetComponent<ItemInfo>().cost)
        {
            slotChecker.AddItemInSlot(nameOfItem, numOfItem);
            statsController.playerMoney -= itemInSlot.GetComponent<ItemInfo>().cost;
            statsController.UpdateMoneyText();
        }
    }
}
