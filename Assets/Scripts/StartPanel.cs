using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private Button startBtn;

    /// <summary>
    /// 点击开始界面按钮事件
    /// </summary>
    public void ClickStart()
    {
        game.SetActive(true);
        startBtn.gameObject.SetActive(false);
    }
}