using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class JsonShopData : MonoBehaviour
{
    public static JsonShopData Instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Json解析shop数据
    /// </summary>
    /// <returns>list集合，泛型为ShopItemData</returns>
    public List<ShopItemData> JsonParseContent()
    {
        StreamReader streamReader = new StreamReader(Application.dataPath + "/Resources/data.json");
        string str = streamReader.ReadToEnd();
        JSONNode json = JSON.Parse(str);
        List<ShopItemData> shopItemDataList = new List<ShopItemData>();
        for (int i = 0; i < json[0].Count; i++)
        {
            var shopData = json[0][i];
            ShopItemData shopItemData = new ShopItemData(shopData["type"],shopData["subType"],
                shopData["costGold"],shopData["isPurchased"]);
            shopItemDataList.Add(shopItemData);
        }
        return shopItemDataList;
    }
}
/// <summary>
/// ShopItemData类：存储商品数据字段信息
/// </summary>
public class ShopItemData
{
    public int type;
    public int subType;
    public int costGold;
    public int isPurchased = -1;//默认值为-1
    
    public ShopItemData(int type,int subType,int costGold,int isPurchased)
    {
        this.type = type;
        this.subType = subType;
        this.costGold = costGold;
        this.isPurchased = isPurchased;
    }
}