using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotChecker : MonoBehaviour
{
    public GameObject[] slotsOfInventory;
    public GameObject[] resources;
    public GameObject[] tools;

    public int itemCount = 0;

    public void CheckItemInSlot(string nameOfItem, int numOfItem)
    {
        for (int i = 0; i < slotsOfInventory.Length; i++)
        {
            Debug.Log(slotsOfInventory[i]);
            Debug.Log(itemCount);
            if (slotsOfInventory[i].transform.childCount == 0 && itemCount == 0)
            {
                switch (nameOfItem)
                {
                    case "r":
                        Instantiate(resources[numOfItem], slotsOfInventory[i].transform);
                        itemCount = 1;
                        break;
                    case "t":
                        Instantiate(tools[numOfItem], slotsOfInventory[i].transform);
                        itemCount = 1;
                        break;
                }
            } else
            {
                GameObject childOfSlot = slotsOfInventory[i].transform.GetChild(0).gameObject;
                ItemInfo itemInfo = childOfSlot.GetComponent<ItemInfo>();
                if (itemInfo.isStackable)
                {
                    if (itemInfo.count < 64)
                    {
                        itemInfo.count++;
                        childOfSlot.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemInfo.count.ToString();
                        itemCount = 1;
                    }
                }
            }
        }
    }
}
