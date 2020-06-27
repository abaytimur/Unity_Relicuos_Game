using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private Text correctNumberText, wrongNumberText, pointsText;

    private int _pointTime = 10;
    private bool _isTimeOver = true;
    private int _totalPoints, _pointsToBeWritten, _increasementPoints;

    [SerializeField] private GameObject pausePanel;

    private void Awake()
    {
        _isTimeOver = true;
    }

    public void ShowResults(int correctNumber, int wrongNumber, int points)
    {
        correctNumberText.text = correctNumber.ToString();
        wrongNumberText.text = wrongNumber.ToString();
        pointsText.text = points.ToString();

        _totalPoints = points;
        _increasementPoints = _totalPoints / 10;

        StartCoroutine(MakePointsWritten());
    }

    IEnumerator MakePointsWritten()
    {
        while (_isTimeOver)
        {
            yield return new WaitForSeconds(0.1f);

            _pointsToBeWritten += _increasementPoints;
            if (_pointsToBeWritten >= _totalPoints)
            {
                _pointsToBeWritten = _totalPoints;
            }

            pointsText.text = _pointsToBeWritten.ToString();

            if (_pointTime <= 0)
            {
                _isTimeOver = false;
            }

            _pointTime--;
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuLevel");
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameLevel");
    }
}