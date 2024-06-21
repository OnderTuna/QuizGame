using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    QuestionSOTemplate currentQuestion;
    [SerializeField] List<QuestionSOTemplate> questionSOList;
    [SerializeField] TextMeshProUGUI questionText;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Button Color")]
    [SerializeField] Sprite defaultButtonSprites;
    [SerializeField] Sprite correctButtonSprites;

    [Header("Timer")]
    [SerializeField] Image timerSprite;
    Timer timerScript;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score scoreScript;

    [Header("Slider")]
    [SerializeField] Slider gameProgressSlider;

    public bool isComplete;

    void Awake()
    {
        timerScript = FindObjectOfType<Timer>();
        scoreScript = FindObjectOfType<Score>();
        gameProgressSlider.maxValue = questionSOList.Count;
    }

    void Update()
    {
        timerSprite.fillAmount = timerScript.fillAmountValue;

        if(timerScript.timeToNextQuestion)
        {
            if (gameProgressSlider.value == gameProgressSlider.maxValue)
            {
                isComplete = true;
                return;
            }

            hasAnsweredEarly = false;
            NextQuestion();
            timerScript.timeToNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timerScript.isAnswering)
        {
            DisplayAnswer(-1);
            ButtonState(false);
        }        
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        ButtonState(false);
        timerScript.CancelTimer();
        scoreText.text = $"Score: %{scoreScript.CalculateScore()}";
    }

    public void DisplayAnswer(int index)
    {
        Image correctButtonImage;
        if (index == correctAnswerIndex)
        {
            questionText.text = "Correct!!!";
            correctButtonImage = answerButtons[index].GetComponent<Image>();
            correctButtonImage.sprite = correctButtonSprites;
            scoreScript.CorrectAnswerCount++;
        }
        else
        {
            string correctAnswer = currentQuestion.AnswerGetter(correctAnswerIndex);
            questionText.text = $"Wrong. Correct answer is: \n{correctAnswer}";
            correctButtonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            correctButtonImage.sprite = correctButtonSprites;
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = currentQuestion.QuestionGetter();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.AnswerGetter(i);
        }
        correctAnswerIndex = currentQuestion.CorrectAnswerIndexGetter();
    }

    private void ButtonState(bool state)
    {
        Button button;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    private void NextQuestion()
    {
        if(questionSOList.Count > 0)
        {
            ButtonState(true);
            ResetButtonsSprite();
            GetRandomQuestion();
            DisplayQuestion();
            scoreScript.SeenQuestionCount++;
            gameProgressSlider.value++;
        }        
    }

    private void GetRandomQuestion()
    {
        int rndIndex = UnityEngine.Random.Range(0, questionSOList.Count);
        currentQuestion = questionSOList[rndIndex];

        if (questionSOList.Contains(currentQuestion))
        {
            questionSOList.Remove(currentQuestion);
        }
    }

    private void ResetButtonsSprite()
    {
        Image buttonImage;

        for(int i = 0; i < answerButtons.Length; i++)
        {
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultButtonSprites;
        }
    }
}
