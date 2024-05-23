using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testNewItems : MonoBehaviour
{
    public SlotChecker slotChecker;

    public void AddItem()
    {
        for (int i = 0; i < 5; i++)
        {
            slotChecker.CheckItemInSlot("r", 0);
        }
        for (int i = 0; i < 4;i++)
        {
            slotChecker.CheckItemInSlot("t", i);
        }
    }
}
