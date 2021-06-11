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
    /// <returns>JSONNode类型数据</returns>
    public JSONNode JsonParseContent()
    {
        StreamReader streamReader = new StreamReader(Application.dataPath + "/Resources/data.json");
        string str = streamReader.ReadToEnd();
        JSONNode json = JSON.Parse(str);
        return json;
    }
}