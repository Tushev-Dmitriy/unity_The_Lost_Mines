using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineReward : MonoBehaviour
{
    public StatsController statsController;
    public SlotChecker slotChecker;
    public ResourceController resourceController;
    public BottleController bottleController;

    public GameObject[] allResource;
    public GameObject itemInMine;
    public GameObject resourceInMine;
    public GameObject toolSlot;
    public bool inMine;

    private bool firstClick = true;
    private int resToSpawn;
    public void SetResource(int numOfRes, int numOfMine)
    {
        resToSpawn = numOfMine;
        if (resourceController.resArray[numOfMine] == null)
        {
            if (itemInMine.transform.childCount > 0)
            {
                Destroy(itemInMine.transform.GetChild(0).gameObject);
            }
            GameObject tempGO = Instantiate(allResource[numOfRes], itemInMine.transform);
            tempGO.transform.localScale = new Vector3(3.45f, 3.45f, 3.45f);
            tempGO.transform.localPosition = Vector3.zero;
            tempGO.GetComponent<CheckTypeOfResource>().mineReward = FindAnyObjectByType<MineReward>();
        } else
        {
            if (itemInMine.transform.childCount > 0)
            {
                Destroy(itemInMine.transform.GetChild(0).gameObject);
            }
            Instantiate(resourceController.resArray[numOfMine], itemInMine.transform);
            itemInMine.transform.GetChild(0).gameObject.GetComponent<CheckTypeOfResource>().mineReward = FindAnyObjectByType<MineReward>();
        }
    }

    public CheckTypeOfResource ReturnResourceInMine()
    {
        //var tempInfo = 
        //CheckTypeOfResource data = gameObject.AddComponent<CheckTypeOfResource>();
        //data.mineReward = tempInfo.mineReward;
        //data.itemInInventory = tempInfo.itemInInventory;
        //data.numOfItem = tempInfo.numOfItem;
        //data.timeToSpawn = tempInfo.timeToSpawn;
        //data.quantity = tempInfo.quantity;
        //data.xp = tempInfo.xp;
        //data.numOfRes = tempInfo.numOfRes;
        return itemInMine.transform.GetChild(0).gameObject.GetComponent<CheckTypeOfResource>();
    }

    public void ClearAllDataAboutItem()
    {
        firstClick = true;
        resourceInMine = null;
    }

    public void UseTool()
    {
        if (toolSlot.transform.childCount == 1 && inMine)
        {
            var toolInfo = toolSlot.transform.GetChild(0).GetComponent<ItemInfo>();
            var itemFullInfo = resourceInMine.GetComponent<CheckTypeOfResource>();
            if (toolInfo.title == "Pickaxe")
            {
                if (firstClick)
                {
                    Debug.Log(123);
                    var itemOfRes = resourceInMine.GetComponent<CheckTypeOfResource>().itemInInventory;
                    var itemInfo = itemOfRes.GetComponent<ItemInfo>();
                    itemFullInfo.numOfRes = resourceInMine.GetComponent<CheckTypeOfResource>().numOfItem;
                    itemFullInfo.timeToSpawn = itemInfo.timeToSpawn;
                    itemFullInfo.quantity = itemInfo.quantity;
                    itemFullInfo.xp = itemInfo.xp;
                    firstClick = false;
                }

                if (itemFullInfo.quantity == 0)
                {
                    Destroy(resourceInMine);
                    statsController.LevelFill(itemFullInfo.xp);
                    StartCoroutine(RespawnResource(itemFullInfo.timeToSpawn));
                    ClearAllDataAboutItem();
                    itemFullInfo.numOfRes = -1;
                }

                slotChecker.AddItemInSlot("r", itemFullInfo.numOfRes);
                itemFullInfo.quantity--;
                toolInfo.durability--;
            }
        }
    }

    IEnumerator RespawnResource(float waitToSpawn)
    {
        int newItem = resToSpawn;
        yield return new WaitForSeconds(waitToSpawn);
        SetResource(newItem, 0);
    }
}
