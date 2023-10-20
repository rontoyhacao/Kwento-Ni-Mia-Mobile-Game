using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string Question = "Enter new question text here";
    [TextArea(2,6)]
    [SerializeField] string TextPurpose = "Enter purpose text here";

    [SerializeField] string[] Answers = new string[3];
    [SerializeField] int CorrectAnswerIndex;

    public string GetQuestion()
    {
        return Question;
    }

    public int GetCorrectAnswerIndex()
    {
        return CorrectAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return Answers[index];
    }

    public string GetTextPurpose()
    {
        return TextPurpose;
    }
}
