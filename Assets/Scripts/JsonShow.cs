using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class JsonShow : MonoBehaviour
{
    public GameObject item;

    private int jsonCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        CreateShopItem(JsonParseContent());
    }
    
    //Json解析数据
    private JSONNode JsonParseContent()
    {
        StreamReader streamReader = new StreamReader(Application.dataPath + "/Resources/data.json");
        string str = streamReader.ReadToEnd();
        JSONNode json = JSON.Parse(str);
        return json;
        
    }
    //动态创建ShopItem资源
    private void CreateShopItem(JSONNode json)
    {
        jsonCount = json[0].Count;
        for (int i = 0; i < jsonCount; i++)
        {
            GameObject itemClone = Instantiate(item, transform);
            var go = itemClone.GetComponent<ShopItem>();
            go.type = json[0][i]["type"];
            go.subType = json[0][i]["subType"];
            go.isPurchased = json[0][i]["isPurchased"];
            go.costGold = json[0][i]["costGold"];
            go.RefreshUI();
        }
        if (json[0].Count % 3 != 0)
        {
            int needNum = 3 - (json[0].Count % 3);
            for (int i = 0; i < needNum; i++)
            {
                Instantiate(item, transform);
            }
        }
    }
}