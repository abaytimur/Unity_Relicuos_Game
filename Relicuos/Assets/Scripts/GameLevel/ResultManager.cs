using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    
    public Animator animator;
    
    [SerializeField] private GameObject restartButton, mainMenuButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private string url;
    
    private RectTransform _rectTransformRestartButton, _rectTransformMainMenuButton;
    private static readonly int StartAnimating = Animator.StringToHash("startAnimating");

    private void Awake()
    {
        _rectTransformRestartButton = restartButton.GetComponent<RectTransform>();
        _rectTransformMainMenuButton = mainMenuButton.GetComponent<RectTransform>();
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
        _rectTransformRestartButton.DOScale(1, 1f).SetEase(Ease.OutBack);
        _rectTransformMainMenuButton.DOScale(1, 1f).SetEase(Ease.OutBack); 
        animator.SetBool(StartAnimating, true);
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

    public void OpenWebsiteUrl()
    {
        Application.OpenURL(url);
    }
}