using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "Inventory/Tool")]
[System.Serializable]
public class Tool : ScriptableObject
{
    public Sprite icon;
    public string title;
    public int cost;
    public int durability;
    public int requiredLevel;
}
