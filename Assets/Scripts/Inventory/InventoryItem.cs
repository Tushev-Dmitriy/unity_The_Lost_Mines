using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Image image;
    public TMP_Text countText;

    [HideInInspector] public string title;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Resource item;
    [HideInInspector] public Tool tool;
    [HideInInspector] public CraftableItem craft;
    [HideInInspector] public int count = 1;

    public void InitialiseItem(Resource newItem)
    {
        item = newItem;
        image.sprite = newItem.icon;
        title = newItem.title;
        RefreshCount();
    }

    public void InitialiseTool(Tool newTool)
    {
        tool = newTool;
        image.sprite = newTool.icon;
        title = newTool.title;
        RefreshCount();
    }

    public void InitialiseCraft(CraftableItem newCraft)
    {
        craft = newCraft;
        image.sprite = newCraft.icon;
        title = newCraft.title;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }
}
