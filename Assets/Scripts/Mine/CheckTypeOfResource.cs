using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTypeOfResource : MonoBehaviour
{
    public MineReward mineReward;
    public GameObject itemInInventory;
    public int numOfItem;

    public float timeToSpawn;
    public int quantity;
    public int xp;
    public int numOfRes;

    public int numOfMine;

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
    }
}
