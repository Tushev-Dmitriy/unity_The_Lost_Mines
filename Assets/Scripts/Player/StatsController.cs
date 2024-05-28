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
        for (int i = 0;i < levelText.Length;i++)
        {
            levelText[i].text = "Уровень " + playerLevel.ToString();
        }
    }

    public void UpdateMoneyText()
    {
        moneyText.text = playerMoney.ToString();
    }
}
