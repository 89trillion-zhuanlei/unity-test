using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public int type;
    public int subType;
    public int costGold;
    public int isPurchased = -1;
    [SerializeField]private Text tagName; //卡牌名字
    [SerializeField]private Image showImage; //卡牌展示图片
    [SerializeField]private GameObject[] state; //状态1：未购买；状态2：已购买；
    [SerializeField]private GameObject[] isCost; //状态1：免费；状态2：付费；

    public void RefreshUI()
    {
        ChangeState(isPurchased);
        if (subType != 0)
        {
            showImage.sprite = Resources.Load<Sprite>("cards/" + subType);
        }

        if (type == 2)
        {
            tagName.gameObject.SetActive(true);
            tagName.text = "Coins";
            showImage.sprite = Resources.Load<Sprite>("coin_1");
            isCost[0].SetActive(true);
        }
        else if (type == 3)
        {
            tagName.gameObject.SetActive(true);
            tagName.text = "Viking Watttior";
            isCost[1].SetActive(true);
            isCost[1].GetComponentInChildren<Text>().text = costGold.ToString();
        }
    }

    private void ChangeState(int isPurchased)
    {
        if (isPurchased != -1)
        {
            state[0].SetActive(false);
            state[1].SetActive(true);
        }
        else
        {
            state[0].SetActive(true);
            state[1].SetActive(false);
        }
    }

    public void CilckBuy()
    {
        isPurchased = 1;
        RefreshUI();
    }
}