using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
public class CreateShopItem : MonoBehaviour
{
    [SerializeField]private ShopItem ShopItem;

    private void Start()
    {
        CreateItem(JsonShopData.Instance.JsonParseContent());
    }

    /// <summary>
    /// 根据Json解析数据的创建ShopItem
    /// </summary>
    /// <param name="json"></param>
    private void CreateItem(JSONNode json)
    {
        int jsonCount  = json[0].Count;
        for (int i = 0; i < jsonCount; i++)
        {
            ShopItem shopitem = Instantiate(ShopItem, transform);
            var shopData = json[0][i];
            shopitem.SetData(shopData["type"],shopData["subType"],
                shopData["costGold"],shopData["isPurchased"]);
            shopitem.RefreshUI();
        }
        if (json[0].Count % 3 != 0)
        {
            int needNum = 3 - (json[0].Count % 3);
            for (int i = 0; i < needNum; i++)
            {
                Instantiate(ShopItem, transform);
            }
        }
    }
}
