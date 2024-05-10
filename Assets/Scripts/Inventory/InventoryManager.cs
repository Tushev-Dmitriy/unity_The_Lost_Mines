using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackItem = 64;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public InventorySlot toolSlot;
    public InventorySlot craftSlot;
    public InventorySlot deleteSlot;
    public InventoryScript inventoryScript;

    public GameObject firstSlot;
    public GameObject firstSlotChild;
    public GameObject secondSlotChild;

    public GameObject[] tools;

    [HideInInspector] public string nameOfSlot;
    [HideInInspector] public bool isStackable;
    [HideInInspector] public Resource resourceItem;
    [HideInInspector] public Tool toolItem;
    [HideInInspector] public CraftableItem craftItem;

    public bool AddItem(object item)
    {
        if (item is Resource)
        {
            isStackable = true;
            Resource resource = item as Resource;
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null && itemInSlot.item == resource && itemInSlot.count < maxStackItem && isStackable)
                {
                    itemInSlot.count++;
                    itemInSlot.RefreshCount();
                    return true;
                }
            }

            for (int i = 0; i < inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot == null)
                {
                    SpawnNewItem(resource, slot);
                    return true;
                }
            }
        }
        else if (item is Tool)
        {
            isStackable = false;
            Tool tool = item as Tool;
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null && itemInSlot.tool == tool && itemInSlot.count < maxStackItem && isStackable)
                {
                    itemInSlot.count++;
                    itemInSlot.RefreshCount();
                    return true;
                }
            }

            for (int i = 0; i < inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot == null)
                {
                    SpawnNewTool(tool, slot);
                    return true;
                }
            }
        }
        else if (item is CraftableItem)
        {
            isStackable = true;
            CraftableItem craft = item as CraftableItem;
            InventorySlot slot = craftSlot;
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                GameObject itemForCraft = craftSlot.gameObject.transform.GetChild(0).gameObject;
                InventoryItem countOfItem = itemForCraft.GetComponent<InventoryItem>();
                SpawnNewCraft(craft, slot);
                GameObject craftItem = craftSlot.gameObject.transform.GetChild(1).gameObject;
                craftItem.transform.GetChild(0).gameObject.SetActive(true);
                InventoryItem countOfCraft = craftItem.GetComponent<InventoryItem>();
                countOfCraft.count = countOfItem.count;
                countOfCraft.RefreshCount();
                Destroy(itemForCraft);
                return true;
            }
        }

        return false;
    }

    public void DeleteItem(InventorySlot slot)
    {
        if (slot.transform.childCount > 0)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                Destroy(itemInSlot.gameObject);
            }
        }
    }

    private void SpawnNewItem(Resource resource, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(resource);
    }

    private void SpawnNewTool(Tool tool, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseTool(tool);
    }

    private void SpawnNewCraft(CraftableItem craft, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseCraft(craft);
    }

    public void CheckItem()
    {
        if (craftSlot.transform.childCount > 0)
        {
            nameOfSlot = craftSlot.GetComponentInChildren<InventoryItem>().title;
            switch (nameOfSlot)
            {
                case "iron":
                    inventoryScript.PickupItem(0, 2);
                    break;

                case "copper":
                    inventoryScript.PickupItem(1, 2);
                    break;

                case "silver":
                    inventoryScript.PickupItem(2, 2);
                    break;

                case "gold":
                    inventoryScript.PickupItem(3, 2);
                    break;
            }
        }
    }

    public void CheckTool()
    {
        if (toolSlot.transform.childCount > 0)
        {
            nameOfSlot = toolSlot.GetComponentInChildren<InventoryItem>().title;
            switch (nameOfSlot)
            {
                case "pickaxe":
                    SetActive();
                    tools[0].SetActive(true);
                    break;

                case "shovel":
                    SetActive();
                    tools[1].SetActive(true);
                    break;

                case "bucket":
                    SetActive();
                    tools[2].SetActive(true);
                    break;

                case "axe":
                    SetActive();
                    tools[3].SetActive(true);
                    break;

                case "bottle":
                    SetActive();
                    tools[4].SetActive(true);
                    break;
            }
        }
    }

    private void SetActive()
    {
        for (int i = 0; i < tools.Length; i++)
        {
            tools[i].SetActive(false);
        }
    }

    public void UseTool()
    {
        if (toolSlot.transform.childCount > 0)
        {
            InventoryItem primeItem = toolSlot.GetComponentInChildren<InventoryItem>();

            switch (nameOfSlot)
            {
                case "pickaxe":
                    primeItem.durability--;
                    if (primeItem.durability == 0)
                    {
                        Destroy(primeItem.gameObject);
                        tools[0].SetActive(false);
                    }
                    break;

                case "shovel":
                    primeItem.durability--;
                    if (primeItem.durability == 0)
                    {
                        Destroy(primeItem.gameObject);
                        tools[1].SetActive(false);
                    }
                    break;

                case "bucket":
                    primeItem.durability--;
                    if (primeItem.durability == 0)
                    {
                        Destroy(primeItem.gameObject);
                        tools[2].SetActive(false);
                    }
                    break;

                case "axe":
                    primeItem.durability--;
                    if (primeItem.durability == 0)
                    {
                        Destroy(primeItem.gameObject);
                        tools[3].SetActive(false);
                    }
                    break;

                case "bottle":
                    break;
            }
        }
    }
}
