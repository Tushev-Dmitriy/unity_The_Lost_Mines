using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTypeOfResource : MonoBehaviour
{
    public MineReward mineReward;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mineReward.resourceInMine = gameObject;
        }
    }
}
