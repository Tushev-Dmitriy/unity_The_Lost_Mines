using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryController : MonoBehaviour
{
    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;

    public GameObject inventorySlots;
    public GameObject slotsParent;

    public void CategoryBtn(int numOfCat)
    {
        switch (numOfCat)
        {
            case 1:
                bg1.SetActive(true);
                bg2.SetActive(false);
                bg3.SetActive(false);
                break;
            case 2:
                bg1.SetActive(false);
                bg2.SetActive(true);
                bg3.SetActive(false);
                break;
            case 3:
                bg1.SetActive(false);
                bg2.SetActive(false);
                bg3.SetActive(true);
                break;
        }
    }
}
