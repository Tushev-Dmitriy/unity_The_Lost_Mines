using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTypeOfResource : MonoBehaviour
{
    public MineReward mineReward;
    public GameObject itemInInventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mineReward.resourceInMine = gameObject;
            mineReward.inMine = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        mineReward.inMine = false;
        mineReward.ClearAllDataAboutItem();
    }
}
