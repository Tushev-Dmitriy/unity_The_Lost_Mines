using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "Inventory/Resource")]
[System.Serializable]
public class Resource: ScriptableObject
{
    public Object prefab;
    public Sprite icon;
    public string title;
    public int cost;
    public int requiredLevel;
    public int timeToSpawn;
    public int quantity;
    public int xp;
}
