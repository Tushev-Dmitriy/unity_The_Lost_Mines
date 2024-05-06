using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Item
{
    public string name;
    public int cost;
    public List<int> requiredLevel;
    public int durability;
    public List<Resource> items;
    public List<CraftableItem> craftableItems;
}

[System.Serializable]
public class Resource
{
    public string name;
    public int cost;
    public int requiredLevel;
    public int timeToSpawn;
    public int xp;
    public int quantity;
}

[System.Serializable]
public class CraftableItem
{
    public string name;
    public List<Recipe> recipe;
    public int cost;
    public int requiredLevel;
}

[System.Serializable]
public class Recipe
{
    public string resource;
    public int quantity;
}

[System.Serializable]
public class ItemList
{
    public List<Item> items;
}


public class JsonParser : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        filePath = $"{Application.dataPath}" + "/StreamingAssets/Inventory.json";
        ParseJSON(filePath);
    }

    void ParseJSON(string json)
    {
        ItemList itemList = JsonUtility.FromJson<ItemList>(File.ReadAllText(json));
        foreach (var item in itemList.items)
        {
            Debug.Log("Item Name: " + item.name);
            Debug.Log("Cost: " + item.cost);
            Debug.Log("Required Levels: " + string.Join(", ", item.requiredLevel.ToArray()));
            if (item.items != null)
            {
                foreach (var resource in item.items)
                {
                    Debug.Log("Resource Name: " + resource.name);
                    Debug.Log("Resource Cost: " + resource.cost);
                    Debug.Log("Required Level: " + resource.requiredLevel);
                    Debug.Log("Time to Spawn: " + resource.timeToSpawn);
                    Debug.Log("XP: " + resource.xp);
                    Debug.Log("Quantity: " + resource.quantity);
                }
            }
            if (item.craftableItems != null)
            {
                foreach (var craftableItem in item.craftableItems)
                {
                    Debug.Log("Craftable Item Name: " + craftableItem.name);
                    Debug.Log("Craftable Item Cost: " + craftableItem.cost);
                    Debug.Log("Required Level: " + craftableItem.requiredLevel);
                    foreach (var recipe in craftableItem.recipe)
                    {
                        Debug.Log("Recipe Resource: " + recipe.resource);
                        Debug.Log("Recipe Quantity: " + recipe.quantity);
                    }
                }
            }
        }
    }
}
