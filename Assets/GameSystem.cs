using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Data
{
    public static int LevelData, ScoreData, TimerData, LivesData;
}

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance;

    int MaxLevel = 5;

    [Header("Game Info")]
    public bool GameStart;
    public bool GameOver;
    public bool RandomSystem;
    public int Target, CurrentDataSet;
    

    [Header("HUD Components")]
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI TimerText, ScoreText;
    public RectTransform LivesIcon;

    [Header("GUI Objects")]
    public GameObject GuiPause;
    public GameObject GuiAnimation;

    [System.Serializable]
    public class DataGame 
    {
        public string FigureSpeechType;
        public string Phrase;
    }

    [Header("Standard Setting")]
    public DataGame[] GameData;

    // add space in inspector
    [Space]

    public ObjDropLocation[] LocationDrop;
    public ObjDrag[] DragObj;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameStart = false;
        GameOver = false;
        ResetData();
        Target = LocationDrop.Length;
        if(RandomSystem)
        {
            RandomizeQuestion();
        }
        CurrentDataSet = 0;
        GameStart = true;
    }

    void ResetData()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game2_0")
        {
            Data.TimerData = 60 * 3;
            Data.LevelData = 0;
            Data.ScoreData = 0;
            Data.LivesData = 5;
        }
    }

    [HideInInspector]public List<int> _RandomQuestion = new List<int>();
    [HideInInspector]public List<int> _RandomPost = new List<int>();
    int random;
    int random2;

    public void RandomizeQuestion()
    {
        _RandomQuestion.Clear();
        _RandomPost.Clear();

        _RandomQuestion = new List<int>(new int[DragObj.Length]);

        for(int i = 0; i < _RandomQuestion.Count; i++)
        {
            random = Random.Range(1, GameData.Length);
            while (_RandomQuestion.Contains(random))
                random = Random.Range(1, GameData.Length);

            _RandomQuestion[i] = random;

            DragObj[i].Id = random - 1;
            DragObj[i].Text.text = GameData[random - 1].FigureSpeechType;
        }

        _RandomPost = new List<int>(new int[LocationDrop.Length]);

        for (int i = 0; i < _RandomPost.Count; i++)
        {
            random2 = Random.Range(1, _RandomQuestion.Count + 1);
            while (_RandomPost.Contains(random2))
                random2 = Random.Range(1, _RandomQuestion.Count + 1);

            _RandomPost[i] = random2;

            LocationDrop[i].Drop.Id = _RandomQuestion[random2 - 1] - 1;
            LocationDrop[i].Drop.FigureOfSpeechType = GameData[LocationDrop[i].Drop.Id].FigureSpeechType;
            LocationDrop[i].Phrase.Text.text = GameData[LocationDrop[i].Drop.Id].Phrase;
        }

    }

    // Update is called once per frame
    float S;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            RandomizeQuestion();

        if (GameStart && !GameOver) 
        {
            if (Data.TimerData > 0) 
            {
                S += Time.deltaTime;
                if (S >= 1)
                {
                    Data.TimerData--;
                    S = 0;
                }
            }
            if (Data.TimerData <= 0)
            {
                GameStart = false;
                GameOver = true;

                SoundCollection.instance.CallSfx(4);
                GuiAnimation.GetComponent<UiControl>().BtnMove("Game2_Over");
            }

            if (Data.LivesData <= 0)
            {
                GameOver = true;
                GameStart = false;

                SoundCollection.instance.CallSfx(4);
                GuiAnimation.GetComponent<UiControl>().BtnMove("Game2_Over");
            }

            if (CurrentDataSet >= Target)
            {
                GameOver = true;
                GameStart = false;

                if (Data.LevelData < (MaxLevel - 1))
                {
                    Data.LevelData++;

                    UnityEngine.SceneManagement.SceneManager.LoadScene("Game2_" + Data.LevelData);
                    //GuiAnimation.GetComponent<UiControl>().BtnMove("Game2_" + Data.LevelData);

                    SoundCollection.instance.CallSfx(3);
                }
                else 
                {
                    GuiAnimation.GetComponent<UiControl>().BtnMove("Game2_Over");
                    SoundCollection.instance.CallSfx(5);
                    SoundCollection.instance.CallSfx(6);
                }
            }
        }

        SetHudInfo();
    }

    public void SetHudInfo() 
    {
        LevelText.text = (Data.LevelData + 1).ToString();

        int minute = Mathf.FloorToInt(Data.TimerData / 60);
        int second = Mathf.FloorToInt(Data.TimerData % 60);
        TimerText.text = minute.ToString("00") + ":" + second.ToString("00");

        ScoreText.text = Data.ScoreData.ToString();

        LivesIcon.sizeDelta = new Vector2(36f * Data.LivesData, 29.742f);
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
