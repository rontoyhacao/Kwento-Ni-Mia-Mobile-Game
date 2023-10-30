using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float TimeToCompleteQuestion = 30f;
    [SerializeField] float TimeToShowCorrectAnswer = 10f;

    public bool LoadNextQuestion;
    public bool IsAnsweringQuestion;
    public float FillFraction;

    public float TimerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer ()
    {
        TimerValue = 0;
    }

    void UpdateTimer()
    {
        TimerValue -= Time.deltaTime;

        if(IsAnsweringQuestion)
        {
            if(TimerValue > 0)
            {
                FillFraction = TimerValue / TimeToCompleteQuestion;
            }
            else
            {
                IsAnsweringQuestion = false;
                TimerValue = TimeToShowCorrectAnswer;
            }
        }
        else
        {
            if (TimerValue > 0)
            {
                FillFraction = TimerValue / TimeToShowCorrectAnswer;
            }
            else
            {
                IsAnsweringQuestion = true;
                TimerValue = TimeToCompleteQuestion;
                LoadNextQuestion = true;
            }
        }
        //Debug.Log(FillFraction);
    }
}
