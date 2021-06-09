using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
using UnityEngine.UI;

public class JsonShow : MonoBehaviour
{
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        jsonParseContent();
    }
    
    //Json解析数据，动态加载item资源
    private void jsonParseContent()
    {
        StreamReader streamReader = new StreamReader(Application.dataPath + "/Resources/data.json");
        string str = streamReader.ReadToEnd();
        JSONNode json = JSON.Parse(str);
        for (int i = 0; i < json[0].Count; i++)
        {
            GameObject itemClone = Instantiate(item, transform);
            var go = itemClone.GetComponent<Item>();
            go.type = json[0][i]["type"];
            go.subType = json[0][i]["subType"];
            go.isPurchased = json[0][i]["isPurchased"];
            go.costGold = json[0][i]["costGold"];
        }
        if (json[0].Count % 3 != 0)
        {
            int needNum = 3 - (json[0].Count % 3);
            for (int i = 0; i < needNum; i++)
            {
                GameObject itemClone = Instantiate(item, transform);
            }
        }
    }
}