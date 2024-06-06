using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsController : MonoBehaviour
{
    public Slider[] level;
    public TMP_Text[] levelText;
    public TMP_Text[] secondLevelText;
    public TMP_Text moneyText;
    public GameObject[] allMines;

    public int playerLevel = 1;
    public int playerMoney = 400;
    private float fillAmountNow = 0;
    private float stockXp = 100;
    private int tempLvl;

    private void Start()
    {
        UpdateMoneyText();
        tempLvl = playerLevel;
    }

    private void Update()
    {
        if (tempLvl != playerLevel)
        {
            stockXp *= 1.75f;
            
            for (int i = 0; i < level.Length; i++)
            {
                level[i].maxValue = stockXp;
            }

            tempLvl++;
        }
    }

    public void LevelFill(float fill)
    {
        fillAmountNow += fill;

        if (fillAmountNow >= stockXp)
        {
            float overflow = fillAmountNow - stockXp;
            LevelUp();
            fillAmountNow = overflow;
        }

        for (int i = 0; i < level.Length; i++)
        {
            level[i].value = fillAmountNow;
            secondLevelText[i].text = level[i].value + "/" + level[i].maxValue;
        }
    }

    private void LevelUp()
    {
        playerLevel++;
        for (int i = 0; i < levelText.Length;i++)
        {
            levelText[i].text = "Уровень " + playerLevel.ToString();
        }
        CheckLvlForResource();
    }

    public void UpdateMoneyText()
    {
        moneyText.text = playerMoney.ToString();
    }

    private void CheckLvlForResource()
    {
        if (playerLevel == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                allMines[Random.Range(0, 6)].GetComponent<GoToMine>().numOfRes = 1;
            }
        } else if (playerLevel == 3)
        {
            for (int i = 0; i < 2; i++)
            {
                allMines[Random.Range(0, 6)].GetComponent<GoToMine>().numOfRes = 2;
            }
        } else if (playerLevel == 4)
        {
            for (int i = 0; i < 1; i++)
            {
                allMines[Random.Range(0, 6)].GetComponent<GoToMine>().numOfRes = 3;
            }
        }
    }
}
