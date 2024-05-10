using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSlot : MonoBehaviour
{
    public GameObject toolSlot;
    public GameObject inventoryCanvas;
    public GameObject inGameCanvas;

    public void SetParentForToolSlot()
    {
        toolSlot.transform.parent = inventoryCanvas.transform;
    }

    public void ReturnParentForSlot()
    {
        toolSlot.transform.parent = inGameCanvas.transform;
    }
}
