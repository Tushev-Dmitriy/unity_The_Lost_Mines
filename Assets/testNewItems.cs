using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testNewItems : MonoBehaviour
{
    public SlotChecker slotChecker;

    public void AddItem()
    {
        slotChecker.CheckItemInSlot("r", 0);
        slotChecker.itemCount = 0;
        slotChecker.CheckItemInSlot("t", 0);
    }
}
