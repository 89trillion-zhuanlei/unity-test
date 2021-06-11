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
    private void CreateItem(List<ShopItemData> shopItemDataList)
    {
        foreach (var dataList in shopItemDataList)
        {
            ShopItem shopitem = Instantiate(ShopItem, transform);
            //shopitem.SetData(dataList);
            shopitem.RefreshUI(dataList);
        }
        if (shopItemDataList.Count % 3 != 0)
        {
            int needNum = 3 - (shopItemDataList.Count % 3);
            for (int i = 0; i < needNum; i++)
            {
                Instantiate(ShopItem, transform);
            }
        }
    }
}
