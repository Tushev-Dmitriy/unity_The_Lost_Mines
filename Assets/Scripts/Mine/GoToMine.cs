using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoToMine : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public MineReward mineReward;
    public ResourceController resourceController;
    public GameObject resourceInfo;

    public int num = 1;
    public int numOfRes;
    public int numOfMine;
    public bool goOut = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (mineReward.resourceInMine != null)
            {
                resourceController.resArray[mineReward.mineToSpawn] = mineReward.ReturnResourceInMine();
                mineReward.resourceInMine = null;
            }

            sceneTransition.number = num;
            sceneTransition.GoInside();

            if (goOut)
            {
                mineReward.mineToSpawn = -1;
            }

            if (!goOut)
            {
                mineReward.SetResource(numOfRes, numOfMine);
            }
        }
    }
}
