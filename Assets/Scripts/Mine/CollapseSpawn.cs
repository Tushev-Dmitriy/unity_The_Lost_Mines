using System.Collections;
using UnityEngine;

public class CollapseSpawn : MonoBehaviour
{
    public GameObject RocksPrefab;
    public int level;

    private MineStatus mineStatus;
    private bool isActive = true;
    private int percent;

    private void Start()
    {
        mineStatus = gameObject.GetComponent<MineStatus>();
    }

    IEnumerator spawnCollapse()
    {
        if (isActive)
        {
            yield return new WaitForSeconds(20f);
            MineStatus.Status currentStatus = mineStatus.GetStatus();
            if (currentStatus != MineStatus.Status.COLLAPSE)
            {
                //spawn rocks prefab
                mineStatus.SetStatus(MineStatus.Status.COLLAPSE);
            }

            yield return new WaitForSeconds(30f);

            if (mineStatus.GetStatus() == MineStatus.Status.COLLAPSE)
            {
                mineStatus.SetStatus(MineStatus.Status.DEPLETED);
                isActive = false;
            } else
            {
                mineStatus.SetStatus(MineStatus.Status.AVAILABALE);
            }
        }
    }
}
