using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SlotChecker : MonoBehaviour
{
    [Header("Items & slots data")]
    public GameObject[] slotsOfInventory;
    public GameObject[] resources;
    public GameObject[] tools;
    public GameObject[] craftableItems;

    [Header("Prime slots")]
    public GameObject craftSlot;
    public GameObject toolSlot;
    public GameObject inventoryGO;
    public GameObject inGameCanvas;

    [Header("Swap slots")]
    public GameObject firstSlot;
    public GameObject secondSlot;
    public GameObject firstSlotChild;
    public GameObject secondSlotChild;

    [Header("Scripts")]
    public StatsController statsController;
    public GameObject itemInHand;

    [HideInInspector] public int itemCount = 0;
    [HideInInspector] public bool isShowItem = false;
    private void Update()
    {
        if (toolSlot.transform.childCount > 0 && !isShowItem)
        {
            GameObject modelInSlot = toolSlot.transform.GetChild(0).gameObject.GetComponent<ItemInfo>().itemModel;
            GameObject tempGO = Instantiate(modelInSlot, itemInHand.transform);
            isShowItem = true;
        } else if (toolSlot.transform.childCount == 0 && isShowItem)
        {
            Destroy(itemInHand.transform.GetChild(0).gameObject);
            isShowItem = false;
        }
    }

    public void AddItemInSlot(string nameOfItem, int numOfItem)
    {
        itemCount = 0;

        for (int i = 0; i < slotsOfInventory.Length - 17; i++)
        {
            if (slotsOfInventory[i].transform.childCount == 1)
            {
                GameObject childOfSlot = slotsOfInventory[i].transform.GetChild(0).gameObject;
                ItemInfo itemInfo = childOfSlot.GetComponent<ItemInfo>();

                string itemName = "";
                switch (nameOfItem)
                {
                    case "r":
                        itemName = resources[numOfItem].name + "(Clone)";
                        break;
                    case "t":
                        itemName = tools[numOfItem].name + "(Clone)";
                        break;
                    case "c":
                        itemName = craftableItems[numOfItem].name + "(Clone)";
                        break;
                }

                if (itemName == itemInfo.name && itemInfo.count < 64 && itemInfo.isStackable)
                {
                    itemInfo.count++;
                    childOfSlot.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemInfo.count.ToString();
                    itemCount = 1;
                    return;
                }
            }
        }

        for (int i = 0; i < slotsOfInventory.Length - 17; i++)
        {
            if (slotsOfInventory[i].transform.childCount == 0)
            {
                switch (nameOfItem)
                {
                    case "r":
                        Instantiate(resources[numOfItem], slotsOfInventory[i].transform);
                        break;
                    case "t":
                        Instantiate(tools[numOfItem], slotsOfInventory[i].transform);
                        break;
                    case "c":
                        Instantiate(craftableItems[numOfItem], slotsOfInventory[i].transform);
                        break;
                }
                itemCount = 1;
                return;
            }
        }
    }

    public void ToolSlotSwap(bool isGame)
    {
        if (!isGame)
        {
            toolSlot.transform.SetParent(inventoryGO.transform);
        } else
        {
            toolSlot.transform.SetParent(inGameCanvas.transform);
        }
    }

    public void SwapSlot(int numOfSlot)
    {
        if (firstSlot == null)
        {
            firstSlot = slotsOfInventory[numOfSlot];
            if (firstSlot.transform.childCount == 0 )
            {
                firstSlot = null;
            }
        } else
        {
            secondSlot = slotsOfInventory[numOfSlot];
            if (secondSlot.transform.childCount == 0 )
            {
                firstSlot.transform.GetChild(0).gameObject.transform.SetParent(secondSlot.transform);
            } else
            {
                firstSlot.transform.GetChild(0).gameObject.transform.SetParent(secondSlot.transform);
                secondSlot.transform.GetChild(0).gameObject.transform.SetParent(firstSlot.transform);
            }
            firstSlot = null;
            secondSlot = null;
        }
    }

    public void CheckCraftItem()
    {
        if (craftSlot.transform.childCount > 0 && statsController.playerLevel >= 2)
        {
            GameObject itemInSlot = craftSlot.transform.GetChild(0).gameObject;
            ItemInfo slotItemInfo = itemInSlot.GetComponent<ItemInfo>();
            if (slotItemInfo.type == TypeOfItem.Resource)
            {
                string nameOfItem = slotItemInfo.name;
                for (int i = 0; i < craftableItems.Length; i++)
                {
                    var recipeForCraft = craftableItems[i].GetComponent<ItemInfo>().recipe;
                    for (int j = 0; j < recipeForCraft.Count; j++)
                    {
                        if (recipeForCraft.Count == 1 && 
                           (recipeForCraft[j].resource + "(Clone)") == nameOfItem)
                        {
                            int countToCraft = recipeForCraft[j].quantity;
                            Instantiate(craftableItems[i], craftSlot.transform);
                            int countOfOldItem = craftSlot.transform.GetChild(0).gameObject.
                                GetComponent<ItemInfo>().count;
                            int countOfNewItem = countOfOldItem / countToCraft;
                            craftSlot.transform.GetChild(1).gameObject.GetComponent<ItemInfo>().
                                count = countOfNewItem;
                            Destroy(itemInSlot);
                        }
                    }
                }
            }
        }
    }

    private void SellItem()
    {
        GameObject currentSlot = EventSystem.current.currentSelectedGameObject;
        Debug.Log(currentSlot);
        if (currentSlot.transform.GetChild(0).GetComponent<ItemInfo>().count == 1)
        {
            statsController.playerMoney += currentSlot.transform.GetChild(0).GetComponent<ItemInfo>().cost;
        } else
        {
            statsController.playerMoney += currentSlot.transform.GetChild(0).GetComponent<ItemInfo>().cost *
                currentSlot.transform.GetChild(0).GetComponent<ItemInfo>().count;
        }   
        statsController.UpdateMoneyText();
        Destroy(currentSlot.transform.GetChild(0).gameObject);
        firstSlot = null;
    }

    public void AddOrRemoveListenerForInteract(bool isAdd)
    {
        if (isAdd)
        {
            for (int i = 0; i < slotsOfInventory.Length - 17; i++)
            {
                if (slotsOfInventory[i].transform.childCount == 1)
                {
                    slotsOfInventory[i].GetComponent<Button>().onClick.AddListener(delegate { SellItem(); });
                }
            }
        }
        else
        {
            for (int i = 0; i < slotsOfInventory.Length - 17; i++)
            {
                slotsOfInventory[i].GetComponent<Button>().onClick.RemoveAllListeners();
            }
        }
    }
}
