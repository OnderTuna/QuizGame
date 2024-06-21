using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timerValue;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    [SerializeField] float timeToCompleteQuestion = 30f;
    public bool isAnswering;
    public float fillAmountValue;
    public bool timeToNextQuestion;

    void Start()
    {

    }
   
    void Update()
    {
        UpateTimer();
    }

    void UpateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnswering)
        {
            if(timerValue > 0)
            {
                fillAmountValue = timerValue / timeToCompleteQuestion; // 1 = 30/30
            }
            else
            {
                isAnswering = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillAmountValue = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnswering = true;
                timerValue = timeToCompleteQuestion;
                timeToNextQuestion = true;
            }
        }

        Debug.Log(fillAmountValue);
    }

    public void CancelTimer()
    {
        timerValue = 0f;
    }
}
