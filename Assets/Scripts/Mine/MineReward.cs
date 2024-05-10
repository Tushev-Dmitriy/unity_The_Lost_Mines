using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineReward : MonoBehaviour
{
    public Resource[] resource;
    public GameObject resourceInMine;
    public GameObject toolBtn;

    private GameObject thisGO;

    public void CheckResource()
    {
        for (int i  = 0; i < resource.Length; i++)
        {
            thisGO = (GameObject)resource[i].prefab;
            if (thisGO.GetComponent<MeshFilter>().sharedMesh == resourceInMine.GetComponent<MeshFilter>().sharedMesh)
            {
                
            }
        }
    }
}
