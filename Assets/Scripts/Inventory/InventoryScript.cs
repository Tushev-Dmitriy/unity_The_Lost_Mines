using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Resource[] itemsToPickup;
    public Tool[] toolsToPickup;
    public CraftableItem[] craftsToPickup;
    public GameObject fullInventory;
    public GameObject lowMoney;

    public int coinCount = 100;
    private bool result;
    public int price = 0;
    public TMP_Text coinText;

    public void PickupItem(int id, int type)
    {
        switch (type)
        {
            case 0:
                result = inventoryManager.AddItem(toolsToPickup[id]);
                break;
            case 1:
                result = inventoryManager.AddItem(itemsToPickup[id]);
                break;
            case 2:
                result = inventoryManager.AddItem(craftsToPickup[id]);
                break;
        }

        if (!result)
        {
            StartCoroutine(showFullInventory());
        }
    }

    public void BuyItem(int id)
    {
        if (coinCount >= price)
        {
            result = inventoryManager.AddItem(itemsToPickup[id]);
            if (result)
            {
                coinCount = coinCount - price;
                coinText.text = coinCount.ToString();
            }
            else
            {
                StartCoroutine(showFullInventory());
            }
        }
        else
        {
            StartCoroutine(showLowMoney());
        }

    }

    IEnumerator showLowMoney()
    {
        lowMoney.GetComponent<Animation>().Play("LowMoney");
        yield return new WaitForSeconds(2.5f);
        lowMoney.GetComponent<Animation>().Play("LowMoneyReverse");
    }

    IEnumerator showFullInventory()
    {
        fullInventory.GetComponent<Animation>().Play("FullInventory");
        yield return new WaitForSeconds(2.5f);
        fullInventory.GetComponent<Animation>().Play("FullInventoryReverse");
    }

    public void SetValue(int value)
    {
        price = value;
    }
}
