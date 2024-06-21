using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "ScriptableObject/QuestionSO")]

public class QuestionSOTemplate : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] private string question;
    [SerializeField] private string[] answers;
    [SerializeField] private int correctAnswerIndex;

    public string QuestionGetter()
    {
        return question;
    }

    public int CorrectAnswerIndexGetter()
    {
        return correctAnswerIndex;
    }

    public string AnswerGetter(int index)
    {
        return answers[index];
    }
}
