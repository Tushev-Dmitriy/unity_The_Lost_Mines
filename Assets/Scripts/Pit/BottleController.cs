using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleController : MonoBehaviour
{
    public GameObject pit;
    public GameObject toolSlot;
    public Slider waterLvl;

    private Color fullBottle = Color.blue;
    private Color defaultBottle = Color.white;

    private void Start()
    {
        StartCoroutine(waterLevel());
    }

    public void UseBottle()
    {
        if (pit.GetComponent<PitController>().canUse && toolSlot.transform.childCount > 0)
        {
            var toolInfo = toolSlot.transform.GetChild(0).GetComponent<ItemInfo>();
            if (toolInfo.title == "Bottle")
            {
                if (toolInfo.count > 0)
                {
                    for (int i = 0; i < toolInfo.count; i++)
                    {
                        waterLvl.value++;
                        toolInfo.count--;
                    }
                }

                if (toolInfo.count == 0)
                {
                    toolSlot.transform.GetChild(0).GetComponent<Image>().color = defaultBottle;
                }
            }
        }
    }

    IEnumerator waterLevel()
    {
        yield return new WaitForSeconds(30f);
        if (waterLvl.value != 0)
        {
            waterLvl.value--;
        } else
        {
            //debuff
        }
    }
}
