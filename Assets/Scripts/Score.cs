using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{    
    int correctAnswerCount = 0;
    int seenQuestionCount = 0;

    public int CorrectAnswerCount
    {
        get
        {
            return correctAnswerCount;
        }

        set 
        {
            correctAnswerCount = value;
        }
    }

    public int SeenQuestionCount
    {
        get
        {
            return seenQuestionCount;
        }

        set
        {
            seenQuestionCount = value;
        }
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(correctAnswerCount / (float)seenQuestionCount * 100);
    }
}
