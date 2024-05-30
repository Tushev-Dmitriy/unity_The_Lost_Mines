using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMine : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public MineReward mineReward;
    public ResourceController resourceController;

    public int num = 1;
    public int numOfRes;
    public int numOfMine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sceneTransition.number = num;
            sceneTransition.GoInside();
            mineReward.SetResource(numOfRes, numOfMine);
            resourceController.resArray[numOfMine] = mineReward.ReturnResourceInMine();
        }
    }
}
