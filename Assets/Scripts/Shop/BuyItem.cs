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

    public void CraftItem()
    {
        GameObject itemInSlot = gameObject.transform.GetChild(0).gameObject;
        List<GameObject> itemsForCraft = new List<GameObject>();
        ItemInfo itemInfo = itemInSlot.GetComponent<ItemInfo>();
        bool canCraft = false;
        int numOfTrue = 0;

        for (int a = 0; a < itemInfo.recipe.Count; a++)
        {
            for (int i = 0; i < slotChecker.slotsOfInventory.Length - 17; i++)
            {
                if (slotChecker.slotsOfInventory[i].transform.childCount != 0)
                {
                    if (slotChecker.slotsOfInventory[i].transform.GetChild(0).name == 
                        (itemInfo.recipe[a].resource + "(Clone)"))
                    {
                        itemsForCraft.Add(slotChecker.slotsOfInventory[i].transform.GetChild(0).gameObject);
                        numOfTrue++;
                    }
                }
            }
        }

        if (numOfTrue == itemInfo.recipe.Count)
        {
            canCraft = true;
            if (statsController.playerLevel >= itemInfo.requiredLevel && canCraft)
            {
                slotChecker.AddItemInSlot(nameOfItem, numOfItem);

                for (int b = 0; b < itemsForCraft.Count; b++)
                {
                    if (itemsForCraft[b].GetComponent<ItemInfo>().count - 1 == 0)
                    {
                        Destroy(itemsForCraft[b]);
                    } else
                    {
                        itemsForCraft[b].GetComponent<ItemInfo>().count--;
                        itemsForCraft[b].GetComponent<ItemInfo>().Start();
                    }
                }
            }
        }
    }
}
