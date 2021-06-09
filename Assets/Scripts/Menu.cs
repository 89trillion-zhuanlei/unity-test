using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject game;
    public Button startBtn;

    public void clickStart()
    {
        game.SetActive(true);
        startBtn.gameObject.SetActive(false);
    }
}