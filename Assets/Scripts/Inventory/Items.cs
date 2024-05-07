using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "Inventory/Resource")]
[System.Serializable]
public class Resource: ScriptableObject
{
    public Sprite icon;
    public string title;
    public int cost;
    public int requiredLevel;
    public int timeToSpawn;
    public int quantity;
    public int xp;
}



[CreateAssetMenu(fileName = "Mineral", menuName = "Inventory/Mineral")]
[System.Serializable]
public class Mineral: ScriptableObject
{
    public string title;
    public int xp;
    public int quantity;
    public int timeToSpawn;
}



[CreateAssetMenu(fileName = "Tool", menuName = "Inventory/Tool")]
[System.Serializable]
public class Tool: ScriptableObject
{
    public string title;
    public int cost;
    public int durability;
    public int requiredLevel;
}



[System.Serializable]
[CreateAssetMenu(fileName = "CraftItem", menuName = "Inventory/CraftItem")]
public class CraftableItem: ScriptableObject
{
    public string title;
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
