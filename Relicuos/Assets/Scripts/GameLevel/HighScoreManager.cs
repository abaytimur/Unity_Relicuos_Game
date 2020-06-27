using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class HighScoreManager : MonoBehaviour
{
    private GameManager _gameManager;
    public Text highScoreNumberText;

    private void Awake()
    {
        _gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        highScoreNumberText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void SetHighScore()
    {
        if (_gameManager.totalPointsForHighScore > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", _gameManager.totalPointsForHighScore);
            highScoreNumberText.text = _gameManager.totalPointsForHighScore.ToString();
        }
    }
}