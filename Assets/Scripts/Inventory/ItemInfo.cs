using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TypeOfItem { Tool, Mineral, Resource, Craft }

[System.Serializable]
public class ItemInfo : MonoBehaviour
{
    [Header ("For all items")]
    public TypeOfItem type;
    public string title;
    public Sprite icon;
    public int cost;
    public int requiredLevel;
    public bool isStackable;
    public int count = 1;
    public GameObject itemModel;

    [Header ("For tools")]
    public int durability;

    [Header ("For resources")]
    public float timeToSpawn;
    public int quantity;
    public int xp;

    [Header("For Craft")]
    public List<RecipeOfCraft> recipe;

    public void Start()
    {
        GetComponent<Image>().sprite = icon;
        if (isStackable)
        {
            GameObject textOfItem = transform.GetChild(0).gameObject;
            textOfItem.SetActive(true);
            textOfItem.GetComponent<TextMeshProUGUI>().text = count.ToString();
        }
    }

    private void Update()
    {
        if (type == TypeOfItem.Tool && durability <= 0)
        {
            Destroy(gameObject);
        }
    }
}

[System.Serializable]
public class RecipeOfCraft
{
    public string resource;
    public int quantity;
}

