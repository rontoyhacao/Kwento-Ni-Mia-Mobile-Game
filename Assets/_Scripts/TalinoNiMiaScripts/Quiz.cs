using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI QuestionText;
    [SerializeField] QuestionSO Question;
    [SerializeField] GameObject[] AnswerButtons;
    int CorrectAnswerIndex;
    [SerializeField] Sprite DefaultAnswerSprite;
    [SerializeField] Sprite CorrectAnswerSprite;

    void Start()
    {
        //DisplayQuestion();
        GetNextQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        CorrectAnswerIndex = Question.GetCorrectAnswerIndex();
        string correctAnswer = Question.GetAnswer(CorrectAnswerIndex);
        string textPurpose = Question.GetTextPurpose();
        if (index == Question.GetCorrectAnswerIndex())
        {
            QuestionText.text = $"Tama! Ang layunin ng may akda sa teksto ay {correctAnswer}. {textPurpose}";
            buttonImage = AnswerButtons[index].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswerSprite;
        }
        else
        {
            QuestionText.text = $"Subukan mo muli! Ang tamang layunin ng may akda sa teksto ay {correctAnswer}. {textPurpose}";
            buttonImage = AnswerButtons[CorrectAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswerSprite;
        }

        SetButtonState(false);
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        QuestionText.text = Question.GetQuestion();
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = Question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            Button button = AnswerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < AnswerButtons.Length; i++)
        {
            Image buttonImage = AnswerButtons[i].GetComponent<Image>();
            buttonImage.sprite = DefaultAnswerSprite;
        }
    }
}
