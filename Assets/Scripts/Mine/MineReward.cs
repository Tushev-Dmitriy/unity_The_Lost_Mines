using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineReward : MonoBehaviour
{
    public StatsController statsController;
    public SlotChecker slotChecker;

    public GameObject[] allResource;
    public GameObject itemInMine;
    public GameObject resourceInMine;
    public GameObject toolSlot;
    public bool inMine;

    private int timeToSpawn;
    private int quantity;
    private int xp;
    private int numOfRes;
    private bool firstClick = true;
    public void SetResource(int numOfRes)
    {
        if (itemInMine.transform.childCount != 0)
        {
            for (int i = 0; i < itemInMine.transform.childCount; i++)
            {
                Destroy(itemInMine.transform.GetChild(i).gameObject);
            }
        }
        GameObject tempGO = Instantiate(allResource[numOfRes], itemInMine.transform);
        tempGO.transform.localScale = new Vector3(3.45f, 3.45f, 3.45f);
        tempGO.transform.localPosition = Vector3.zero;
        tempGO.GetComponent<CheckTypeOfResource>().mineReward = FindAnyObjectByType<MineReward>();
    }

    public void ClearAllDataAboutItem()
    {
        timeToSpawn = 0;
        quantity = 0;
        xp = 0;
        numOfRes = -1;
        firstClick = true;
        resourceInMine = null;
    }

    public void UseTool()
    {
        if (toolSlot.transform.childCount == 1 && inMine)
        {
            var toolInfo = toolSlot.transform.GetChild(0).GetComponent<ItemInfo>();
            if (toolInfo.title == "Pickaxe")
            {
                if (firstClick)
                {
                    var itemOfRes = resourceInMine.GetComponent<CheckTypeOfResource>().itemInInventory;
                    var itemInfo = itemOfRes.GetComponent<ItemInfo>();
                    numOfRes = resourceInMine.GetComponent<CheckTypeOfResource>().numOfItem;
                    timeToSpawn = itemInfo.timeToSpawn;
                    quantity = itemInfo.quantity;
                    xp = itemInfo.xp;
                    firstClick = false;
                }

                if (quantity == 0)
                {
                    Destroy(resourceInMine);
                    statsController.LevelFill(xp);
                    ClearAllDataAboutItem();
                    numOfRes = -1;
                }

                slotChecker.AddItemInSlot("r", numOfRes);
                quantity--;
                toolInfo.durability--;
            }
        }
    }
}
