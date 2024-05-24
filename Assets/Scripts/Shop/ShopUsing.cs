using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUsing : MonoBehaviour
{
    public GameObject shopBtn;
    public GameObject shopUi;
    public GameObject playerInGame;
    public StatsController statsController;

    private Animation shopAnim;
    private bool shopRunning = false;

    private void Start()
    {
        shopAnim = shopBtn.GetComponent<Animation>();
        shopUi = GameObject.FindGameObjectWithTag("Shop");
    }
    public void ShowShopBtn()
    {
        if (shopRunning)
        {
            shopAnim.Play("ShopBtnReverse");
            shopRunning = false;
        }
        else
        {
            shopAnim.Play("ShopBtn");
            shopRunning = true;
        }
    }

    public void ShowShopInterface()
    {
        if (shopRunning)
        {
            shopUi.SetActive(true);
            shopRunning = false;
        }
        else
        {
            shopUi.SetActive(false);
            shopRunning = true;
        }
    }

    public void ClearShopInterface()
    {
        shopAnim.Play("ShopBtnReverse");
        shopUi.SetActive(false);
        shopRunning = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShowShopBtn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ShowShopBtn();
        }
    }
}
