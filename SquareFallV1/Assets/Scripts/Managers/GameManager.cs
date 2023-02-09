using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public bool IsGamePlaying { get; set;}

    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }

        IsGamePlaying = false;
    }

    private void Update()
    {
        if (Input.anyKey && !IsGamePlaying)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        IsGamePlaying = true;
        
        FindObjectOfType<BoarderObjectSpawner>().SpawnObject();
        FindObjectOfType<ObjectSpawner>().SpawnObject();
        
        UIManager.Instance.StartGame();
    }

    public void IncreaseScore()
    {
        if (Instance.IsGamePlaying)
        {
            UIManager.Instance.IncreaseScore();
            AudioManager.Instance.PlaySfx(1);
        }
    }

    public void GameOver()
    {
        AudioManager.Instance.PlaySfx(2);
        UIManager.Instance.ShowFinalResult();
        
        IsGamePlaying = false;
        
        gameOverPanel.SetActive(!IsGamePlaying);
    }
}
