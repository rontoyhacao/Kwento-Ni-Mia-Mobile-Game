using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameSystem2 : MonoBehaviour
{
    [Header("Game Info")]
    public bool GameStart;
    public bool GameOver;

    [Header("GUI Objects")]
    public GameObject GuiPause;
    public GameObject GuiAnimation;

    // Start is called before the first frame update
    void Start()
    {
        GameStart = false;
        GameOver = false;
        GameStart = true;
    }

    void Update()
    {

    }

    public void SetHudInfo()
    {

    }

    public void BtnPause(bool pause)
    {
        if (pause)
        {
            GameStart = false;
            GuiPause.SetActive(true);
        }
        else
        {
            GameStart = true;
            GuiPause.SetActive(false);
        }
    }
}
