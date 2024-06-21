using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endScreenText;
    Score scoreScript;

    void Awake()
    {
        scoreScript = FindObjectOfType<Score>();
    }

    public void ShowScore()
    {
        endScreenText.text = $"Congratulations.\nYour score is {scoreScript.CalculateScore()}";
    }
}
