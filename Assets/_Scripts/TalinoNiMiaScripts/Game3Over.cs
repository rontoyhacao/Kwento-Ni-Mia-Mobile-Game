using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game3Over : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;

    private void Start()
    {
        ScoreText.text = Data2.ScoreData.ToString() + "%";
    }
}
