using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Data2
{
    public static int LevelData, ScoreData, TimerData, LivesData;
}

public class GameSystem1 : MonoBehaviour
{
    public static GameSystem1 Instance;

    [Header("Game Info")]
    public bool GameStart;
    public bool GameOver;
    

    [Header("HUD Components")]
    public TextMeshProUGUI TimerText, ScoreText;

    [Header("GUI Objects")]
    public GameObject GuiPause;
    public GameObject GuiAnimation;

    [System.Serializable]
    public class DataGame 
    {
        public string FigureSpeechType;
        public string Phrase;
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameStart = false;
        GameOver = false;
        GameStart = true;
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
