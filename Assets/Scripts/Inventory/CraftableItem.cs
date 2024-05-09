using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CraftItem", menuName = "Inventory/CraftItem")]
public class CraftableItem : ScriptableObject
{
    public Sprite icon;
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