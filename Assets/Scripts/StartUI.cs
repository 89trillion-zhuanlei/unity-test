using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public GameObject game;
    public Button startBtn;

    public void ClickStart()
    {
        game.SetActive(true);
        startBtn.gameObject.SetActive(false);
    }
}