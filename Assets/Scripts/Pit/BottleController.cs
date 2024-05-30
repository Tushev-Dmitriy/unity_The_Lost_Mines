using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleController : MonoBehaviour
{
    public GameObject pit;
    public GameObject toolSlot;
    public void UseBottle()
    {
        if (pit.GetComponent<PitController>().canUse && toolSlot.transform.childCount > 0)
        {
            var toolInfo = toolSlot.transform.GetChild(0).GetComponent<ItemInfo>();
            if (toolInfo.title == "Bottle")
            {
                Debug.Log(1);
            }
        }
    }
}
