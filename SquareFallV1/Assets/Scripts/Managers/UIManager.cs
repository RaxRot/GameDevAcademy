using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private TMP_Text scoreText;
    private int _score;

    [SerializeField] private TMP_Text finalScoreText, finalHighScoreText;
    
    [SerializeField] private TMP_Text startInstructionTxt;

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SetValues();
    }

    private void SetValues()
    {
        scoreText.text = _score.ToString();
        scoreText.enabled = false;
    }

    public void IncreaseScore()
    {
        _score++;
        scoreText.text = _score.ToString();
    }

    public void ShowFinalResult()
    {
        if (PlayerPrefs.HasKey(TagManager.HIGHT_SCORE_PREF))
        {
            if (_score>PlayerPrefs.GetInt(TagManager.SCORE_TAG))
            {
               SetBestScore();
            }
            else
            {
                finalHighScoreText.text = PlayerPrefs.GetInt(TagManager.HIGHT_SCORE_PREF).ToString();
            }
        }
        else
        {
            SetBestScore();
        }

        finalScoreText.text = _score.ToString();
    }

    private void SetBestScore()
    {
        PlayerPrefs.SetInt(TagManager.HIGHT_SCORE_PREF,_score);
        finalHighScoreText.text = _score.ToString();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        scoreText.enabled = true;
        startInstructionTxt.enabled = false;
    }
}
