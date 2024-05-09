using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackItem = 64;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public InventorySlot primeSlot;
    public InventorySlot deleteSlot;
    public InventoryScript inventoryScript;

    public GameObject firstSlot;
    public GameObject firstSlotChild;
    public GameObject secondSlotChild;

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
            InventorySlot slot = primeSlot;
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                GameObject itemForCraft = primeSlot.gameObject.transform.GetChild(0).gameObject;
                InventoryItem countOfItem = itemForCraft.GetComponent<InventoryItem>();
                SpawnNewCraft(craft, slot);
                GameObject craftItem = primeSlot.gameObject.transform.GetChild(1).gameObject;
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
        if (primeSlot.transform.childCount > 0)
        {
            nameOfSlot = primeSlot.GetComponentInChildren<InventoryItem>().title;
            switch (nameOfSlot)
            {
                case "iron":
                    inventoryScript.PickupItem(0, 2);
                    break;
            }
        }
    }
}
