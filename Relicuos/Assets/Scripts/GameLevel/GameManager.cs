using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pointAndTimePanel;
    [SerializeField] private GameObject getPointImage, pickBiggerNumberImage;
    [SerializeField] private GameObject upperRectImage;
    [SerializeField] private GameObject lowerRectImage;
    [SerializeField] private GameObject pausePanel, resultPanel;
    [SerializeField] private Text lowerRectText;
    [SerializeField] private Text upperRectText;
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioClip startSound, correctSound, wrongSound, endSound;
    
    private HighScoreManager _highScoreManager;
    private CountDownManager _countDownManager;
    private TimerManager _timerManager;
    private CirclesManager _circlesManager;
    private TrueFalseManager _trueFalseManager;
    private ResultManager _resultManager;
    private CanvasGroup _canvasGroup;
    private CanvasGroup _canvasGroup1;

    private int _gameCounter, _whichNumberOfGame;
    private int _upperValue, _lowerValue;
    private int _greaterValue;
    private int _buttonValue;
    private int _totalPoints; 
    private int _increasePoints;
    private int _correctNumberText, _wrongNumberText;
    [NonSerialized] public int totalPointsForHighScore;
    
    private AudioSource _audioSource;

    private void Awake()
    {
        _highScoreManager = Object.FindObjectOfType<HighScoreManager>();
        _countDownManager = Object.FindObjectOfType<CountDownManager>();
        _trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();
        _timerManager = Object.FindObjectOfType<TimerManager>();
        _circlesManager = Object.FindObjectOfType<CirclesManager>();

        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = getPointImage.GetComponent<CanvasGroup>();
        _canvasGroup1 = pickBiggerNumberImage.GetComponent<CanvasGroup>();
        _gameCounter = 0;
        _whichNumberOfGame = 0;
        _totalPoints = 0;

        lowerRectText.text = "";
        upperRectText.text = "";
        scoreText.text = "0";

        UpdateSceneView();
    }

    private void UpdateSceneView()
    {
        pointAndTimePanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        getPointImage.GetComponent<CanvasGroup>().DOFade(1, 1f);

        upperRectImage.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);
        lowerRectImage.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutBack);

        StartGame();
    }

    public void StartGame()
    {
        _audioSource.PlayOneShot(startSound);

        Invoke(nameof(FadeInCanvasGroupForInvoke2),3.5f);
        Invoke(nameof(FadeInCanvasGroupForInvoke),3.5f);
        WhichNumberOfGame();

        StartCoroutine(_countDownManager.CountDownRoutine());
        Invoke(nameof(StartTimer),2.4f);
    }

    private void FadeInCanvasGroupForInvoke()
    {
        _canvasGroup1.DOFade(1, 5f).SetEase(Ease.OutBack);
    }
    
    private void FadeInCanvasGroupForInvoke2()
    {
        _canvasGroup.DOFade(0, 5f).SetEase(Ease.OutBack);
    }


    private void StartTimer()
    {
        _timerManager.StartTimer();
    }
    
    void WhichNumberOfGame()
    {
        if (_gameCounter < 5)
        {
            _whichNumberOfGame = 1;
            _increasePoints = 25;
        }
        else if (_gameCounter >= 5 && _gameCounter < 10)
        {
            _whichNumberOfGame = 2;
            _increasePoints = 50;
        }
        else if (_gameCounter >= 10 && _gameCounter < 15)
        {
            _whichNumberOfGame = 3;
            _increasePoints = 75;
        }
        else if (_gameCounter >= 15 && _gameCounter < 20)
        {
            _whichNumberOfGame = 4;
            _increasePoints = 100;
        }
        else if (_gameCounter >= 20 && _gameCounter < 25)
        {
            _whichNumberOfGame = 5;
            _increasePoints = 125;
        }
        else if (_gameCounter >= 25)
        {
            _whichNumberOfGame = Random.Range(1, 6);
            _increasePoints = 150;
        }

        switch (_whichNumberOfGame)
        {
            case 1:
                FirstFunction();
                break;
            case 2:
                SecondFunction();
                break;
            case 3:
                ThirdFunction();
                break;
            case 4:
                ForthFunction();
                break;
            case 5:
                FifthFunction();
                break;
        }
    }

    void FirstFunction()
    {
        int randomValue = Random.Range(1, 50);

        if (randomValue <= 25)
        {
            _upperValue = Random.Range(2, 50);
            _lowerValue = _upperValue + Random.Range(1, 15);
        }
        else
        {
            _upperValue = Random.Range(2, 50);
            _lowerValue = Mathf.Abs(_upperValue - Random.Range(1, 15));
        }

        if (_upperValue > _lowerValue)
        {
            _greaterValue = _upperValue;
        }
        else if (_upperValue < _lowerValue)
        {
            _greaterValue = _lowerValue;
        }
        else if (_upperValue == _lowerValue)
        {
            FirstFunction();
            return;
            ;
        }

        upperRectText.text = _upperValue.ToString();
        lowerRectText.text = _lowerValue.ToString();
    }

    void SecondFunction()
    {
        int firstNumber = Random.Range(1, 15);
        int secondNumber = Random.Range(1, 20);
        int thirdNumber = Random.Range(1, 15);
        int forthNumber = Random.Range(1, 20);

        _upperValue = firstNumber + secondNumber;
        _lowerValue = thirdNumber + forthNumber;

        if (_upperValue > _lowerValue)
        {
            _greaterValue = _upperValue;
        }
        else if (_upperValue < _lowerValue)
        {
            _greaterValue = _lowerValue;
        }
        else if (_upperValue == _lowerValue)
        {
            SecondFunction();
            return;
        }

        upperRectText.text = firstNumber + "+" + secondNumber;
        lowerRectText.text = thirdNumber + "+" + forthNumber;
    }

    void ThirdFunction()
    {
        int firstNumber = Random.Range(11, 50);
        int secondNumber = Random.Range(1, 15);
        int thirdNumber = Random.Range(11, 50);
        int forthNumber = Random.Range(1, 15);

        _upperValue = firstNumber - secondNumber;
        _lowerValue = thirdNumber - forthNumber;

        if (_upperValue > _lowerValue)
        {
            _greaterValue = _upperValue;
        }
        else if (_upperValue < _lowerValue)
        {
            _greaterValue = _lowerValue;
        }
        else if (_upperValue == _lowerValue)
        {
            ThirdFunction();
            return;
        }

        upperRectText.text = firstNumber + "-" + secondNumber;
        lowerRectText.text = thirdNumber + "-" + forthNumber;
    }

    void ForthFunction()
    {
        int firstNumber = Random.Range(1, 10);
        int secondNumber = Random.Range(1, 10);
        int thirdNumber = Random.Range(1, 10);
        int forthNumber = Random.Range(1, 10);

        _upperValue = firstNumber * secondNumber;
        _lowerValue = thirdNumber * forthNumber;

        if (_upperValue > _lowerValue)
        {
            _greaterValue = _upperValue;
        }
        else if (_upperValue < _lowerValue)
        {
            _greaterValue = _lowerValue;
        }
        else if (_upperValue == _lowerValue)
        {
            ForthFunction();
            return;
        }

        upperRectText.text = firstNumber + " x " + secondNumber;
        lowerRectText.text = thirdNumber + " x " + forthNumber;
    }

    void FifthFunction()
    {
        int firstNumber = Random.Range(2, 10);
        _upperValue = Random.Range(2, 10);

        int secondNumber = firstNumber * _upperValue;

        int thirdNumber = Random.Range(2, 10);
        _lowerValue = Random.Range(2, 10);
        int forthNumber = thirdNumber * _lowerValue;

        if (_upperValue > _lowerValue)
        {
            _greaterValue = _upperValue;
        }
        else if (_upperValue < _lowerValue)
        {
            _greaterValue = _lowerValue;
        }
        else if (_upperValue == _lowerValue)
        {
            FifthFunction();
            return;
        }

        upperRectText.text = secondNumber + " : " + firstNumber;
        lowerRectText.text = forthNumber + " : " + thirdNumber;
    }

    public void SelectButtonValue(string buttonName)
    {
        if (buttonName == "upperButton")
        {
            _buttonValue = _upperValue;
        }
        else if (buttonName == "lowerButton")
        {
            _buttonValue = _lowerValue;
        }

        if (_buttonValue == _greaterValue)
        {
            _circlesManager.TurnOnCirclesScales(_gameCounter % 5);
            _gameCounter++;

            _trueFalseManager.TrueFalseImagesLocalScaleAdjuster(true);
            _totalPoints += _increasePoints;

            scoreText.text = _totalPoints.ToString();

            _correctNumberText++;

            _audioSource.PlayOneShot(correctSound);

            WhichNumberOfGame();
        }
        else
        {
            _trueFalseManager.TrueFalseImagesLocalScaleAdjuster(false);
            LowerTheCounterIfPlayerFails();
            _wrongNumberText++;
            
            PointsDecrease();
            scoreText.text = _totalPoints.ToString();
          
            
            _audioSource.PlayOneShot(wrongSound);

            WhichNumberOfGame();
        }
    }

    private void PointsDecrease()
    {
        _totalPoints -= 10 * _whichNumberOfGame;
        if (_totalPoints <= 0)
        {
            _totalPoints = 0;
        }
    }

    void LowerTheCounterIfPlayerFails()
    {
        _gameCounter -= (_gameCounter % 5 + 5);

        if (_gameCounter < 0)
        {
            _gameCounter = 0;
        }

        _circlesManager.TurnOffCirclesScales();
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void EndTheGame()
    {
        _audioSource.PlayOneShot(endSound);
        
        totalPointsForHighScore = _totalPoints;
        _highScoreManager.SetHighScore();
        
        resultPanel.SetActive(true);
        _resultManager = Object.FindObjectOfType<ResultManager>();
        _resultManager.ShowResults(_correctNumberText, _wrongNumberText, _totalPoints);
    }
}