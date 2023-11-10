using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Data3
{
    public static int ScoreData;
}

public class GameSystem2 : MonoBehaviour
{
    //public static GameSystem1 Instance;
    Game1Quiz Game1Quiz;

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

    //private void Awake()
    //{
    //    Instance = this;
    //}

    // Start is called before the first frame update
    void Start()
    {
        GameStart = false;
        GameOver = false;
        GameStart = true;

        Game1Quiz = FindAnyObjectByType<Game1Quiz>();
    }

    void Update()
    {
        // ignore timer in story scenes
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Game1_Quiz")
        {
            if (Game1Quiz.IsComplete)
            {
                GuiAnimation.GetComponent<UiControl>().BtnMove("Game1_QuizOver");
                //SoundCollection.instance.CallSfx(5);
                //SoundCollection.instance.CallSfx(6);
            }
        }
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
