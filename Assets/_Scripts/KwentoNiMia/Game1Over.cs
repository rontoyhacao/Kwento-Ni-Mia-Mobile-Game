using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game1Over : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;

    private void Start()
    {
        ScoreText.text = Data3.ScoreData.ToString() + "%";
    }
}
