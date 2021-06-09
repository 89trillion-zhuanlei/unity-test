using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int type;
    public int subType;
    public int costGold;
    public int isPurchased = -1;
    public Text tagName; //卡牌名字
    public Image showImage; //卡牌展示图片
    public GameObject[] state; //状态1：未购买；状态2：已购买；
    public GameObject[] isCost; //状态1：免费；状态2：付费；
    
    void Update()
    {
        if (subType != 0)
        {
            showImage.sprite = Resources.Load<Sprite>("cards/" + subType);
        }
        if (isPurchased == 1)
        {
            state[1].SetActive(true);
            state[0].SetActive(false);
        }
        else if (isPurchased == -1)
        {
            state[0].SetActive(true);
            state[1].SetActive(false);
        }

        if (type == 2)
        {
            tagName.text = "Coins";
            isCost[0].SetActive(true);
            showImage.sprite = Resources.Load<Sprite>("coin_1");
        }
        else if (type == 3)
        {
            tagName.text = "Viking Watttior";
            isCost[1].SetActive(true);
            isCost[1].GetComponentInChildren<Text>().text = costGold.ToString();
        }
        else
        {
            tagName.gameObject.SetActive(false);
            state[0].SetActive(false);
            isCost[0].SetActive(false);
            isCost[1].SetActive(false);
        }
    }

    public void cilckBuy()
    {
        isPurchased = 1;
    }
}