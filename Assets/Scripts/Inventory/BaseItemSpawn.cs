using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItemSpawn : MonoBehaviour
{
    public SlotChecker slotChecker;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            slotChecker.AddItemInSlot("t", i);
        }

        for (int i = 0; i < 5; i++)
        {
            slotChecker.AddItemInSlot("r", 0);
        }
    }
}
