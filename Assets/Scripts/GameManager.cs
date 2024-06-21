using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quizScript;
    EndScript endScript;

    private void Awake()
    {
        quizScript = FindObjectOfType<Quiz>();
        endScript = FindObjectOfType<EndScript>();
    }

    void Start()
    {
        quizScript.gameObject.SetActive(true);
        endScript.gameObject.SetActive(false);
    }
    
    void Update()
    {
        if(quizScript.isComplete)
        {
            quizScript.gameObject.SetActive(false);
            endScript.gameObject.SetActive(true);
            endScript.ShowScore();
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
