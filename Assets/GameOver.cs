using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI ScoreText, HighScoreText;

    private void Start()
    {
        if (Data.ScoreData >= PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", Data.ScoreData);
        }

        ScoreText.text = Data.ScoreData.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("score").ToString();
    }
}
