using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsController : MonoBehaviour
{
    public Slider[] level;
    public TMP_Text levelText;

    public TMP_Text moneyText;

    public int playerLevel = 1;
    public int playerMoney = 400;
    private float fillAmountNow = 0;

    private void Start()
    {
        UpdateMoneyText();
    }

    public void LevelFill(float fill)
    {
        fillAmountNow += fill;

        if (fillAmountNow >= 1)
        {
            float overflow = fillAmountNow - 1;
            LevelUp();
            fillAmountNow = overflow;
        }

        for (int i = 0; i < level.Length; i++)
        {
            level[i].value = fillAmountNow;
        }
    }

    private void LevelUp()
    {
        playerLevel++;
        levelText.text = playerLevel.ToString();
    }

    public void UpdateMoneyText()
    {
        moneyText.text = playerMoney.ToString();
    }
}
