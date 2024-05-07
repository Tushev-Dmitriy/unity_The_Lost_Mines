using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Image image;
    public TMP_Text countText;

    [HideInInspector] public string title;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Resource item;
    [HideInInspector] public int count = 1;

    public void InitialiseItem(Resource newItem)
    {
        item = newItem;
        image.sprite = newItem.icon;
        title = newItem.title;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }
}
