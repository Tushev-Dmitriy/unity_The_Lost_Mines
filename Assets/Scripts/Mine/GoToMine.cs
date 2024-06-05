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
                resourceController.resArray[numOfMine] = mineReward.ReturnResourceInMine();
                mineReward.resourceInMine = null;
                mineReward.firstClick = true;
            }

            sceneTransition.number = num;
            sceneTransition.GoInside();
            
            if (!goOut)
            {
                mineReward.SetResource(numOfRes, numOfMine);
            }
        }
    }

    private void DeletePastInfo()
    {
        CheckTypeOfResource[] allInfo = resourceInfo.GetComponents<CheckTypeOfResource>();
        for (int i = 0; i < allInfo.Length; i++)
        {
            if (allInfo[i].numOfMine == numOfMine)
            {
                Destroy(allInfo[i]);
            }
        }
    }
}
