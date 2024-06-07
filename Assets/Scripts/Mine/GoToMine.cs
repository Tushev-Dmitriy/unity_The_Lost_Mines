using UnityEngine;
using UnityEngine.UI;

public class GoToMine : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public MineReward mineReward;
    public ResourceController resourceController;
    public GameObject resourceInfo;
    public GameObject tpBtn;

    public int num = 1;
    public int numOfRes;
    public int numOfMine;
    public bool goOut = false;

    private Button tpBtnComp;

    private void Start()
    {
        tpBtnComp = tpBtn.GetComponent<Button>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tpBtn.GetComponent<Animation>().Play("ShopBtn");
            tpBtnComp.onClick.AddListener(delegate { TeleportInMine(); });
            tpBtnComp.onClick.AddListener(delegate { TeleportInMine(); });
        }
    }

    public void TeleportInMine()
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

        tpBtn.GetComponent<Animation>().Play("ShopBtnReverse");
        tpBtnComp.onClick.RemoveAllListeners();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            tpBtn.GetComponent<Animation>().Play("ShopBtnReverse");
            tpBtnComp.onClick.RemoveAllListeners();
        }
    }
}
