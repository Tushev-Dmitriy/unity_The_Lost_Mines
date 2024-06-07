using System.Collections;
using UnityEngine;

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
    public GameObject resourceInfo;
    public bool inMine;
    public GameObject[] allMines;

    public int resToSpawn;
    public int mineToSpawn;
    public void SetResource(int numOfRes, int numOfMine)
    {
        resToSpawn = numOfRes;
        mineToSpawn = numOfMine;
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
            tempGO.GetComponent<CheckTypeOfResource>().numOfMine = numOfMine;
        } else
        {
            if (itemInMine.transform.childCount > 0)
            {
                Destroy(itemInMine.transform.GetChild(0).gameObject);
            }
            GameObject tempGO = Instantiate(allResource[numOfRes], itemInMine.transform);

            tempGO.transform.localPosition = Vector3.zero;
            tempGO.transform.localScale = new Vector3(3.45f, 3.45f, 3.45f);

            CheckTypeOfResource itemInfo = null;
            CheckTypeOfResource[] itemInfoArray = resourceInfo.GetComponents<CheckTypeOfResource>();
            for (int i = 0; i < itemInfoArray.Length; i++)
            {
                if (itemInfoArray[i].numOfMine == numOfMine)
                {
                    itemInfo = itemInfoArray[i];
                }
            }

            if (itemInfo != null)
            {
                CheckTypeOfResource newItemInfo = tempGO.GetComponent<CheckTypeOfResource>();

                newItemInfo.mineReward = FindAnyObjectByType<MineReward>();
                newItemInfo.itemInInventory = resourceController.resArray[numOfMine].itemInInventory;
                newItemInfo.numOfItem = resourceController.resArray[numOfMine].numOfItem;
                newItemInfo.timeToSpawn = resourceController.resArray[numOfMine].timeToSpawn;
                newItemInfo.quantity = resourceController.resArray[numOfMine].quantity;
                newItemInfo.xp = resourceController.resArray[numOfMine].xp;
                newItemInfo.numOfRes = resourceController.resArray[numOfMine].numOfRes;

                Destroy(itemInfo);
            }
        }
    }

    public CheckTypeOfResource ReturnResourceInMine()
    {
        var tempInfo = resourceInMine.GetComponent<CheckTypeOfResource>();
        var data = gameObject.transform.GetChild(0).gameObject.AddComponent<CheckTypeOfResource>();
        data.mineReward = tempInfo.mineReward;
        data.itemInInventory = tempInfo.itemInInventory;
        data.numOfItem = tempInfo.numOfItem;
        data.timeToSpawn = tempInfo.timeToSpawn;
        data.quantity = tempInfo.quantity;
        data.xp = tempInfo.xp;
        data.numOfRes = tempInfo.numOfRes;
        data.numOfMine = tempInfo.numOfMine;

        CheckTypeOfResource[] itemInfoArray = resourceInfo.GetComponents<CheckTypeOfResource>();
        for (int i = 0; i < itemInfoArray.Length; i++)
        {
            if (itemInfoArray[i].numOfMine == mineToSpawn)
            {
                return itemInfoArray[i];
            }
        }
        return null;
    }

    public void ClearAllDataAboutItem()
    {
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
                if (resourceInMine.GetComponent<CheckTypeOfResource>().xp == 0)
                {
                    var itemOfRes = resourceInMine.GetComponent<CheckTypeOfResource>().itemInInventory;
                    var itemInfo = itemOfRes.GetComponent<ItemInfo>();
                    itemFullInfo.numOfRes = resourceInMine.GetComponent<CheckTypeOfResource>().numOfItem;
                    itemFullInfo.timeToSpawn = itemInfo.timeToSpawn;
                    itemFullInfo.quantity = itemInfo.quantity;
                    itemFullInfo.xp = itemInfo.xp;
                }

                if (itemFullInfo.quantity == 0)
                {
                    Destroy(resourceInMine);
                    statsController.LevelFill(itemFullInfo.xp);
                    StartCoroutine(RespawnResource(itemFullInfo.timeToSpawn, mineToSpawn));
                    ClearAllDataAboutItem();
                    itemFullInfo.numOfRes = -1;
                }

                slotChecker.AddItemInSlot("r", itemFullInfo.numOfRes);
                itemFullInfo.quantity--;
                toolInfo.durability--;
            }
        }
    }

    IEnumerator RespawnResource(float waitToSpawn, int numOfMine)
    {
        yield return new WaitForSeconds(waitToSpawn);
        resourceController.resArray[numOfMine] = null;
        resToSpawn = allMines[numOfMine].GetComponent<GoToMine>().numOfRes;
        int newItem = resToSpawn;
        SetResource(newItem, numOfMine);
    }
}
