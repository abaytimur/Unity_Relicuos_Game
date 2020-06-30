using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private Text timerText;

    private int _remainingTime;
    private bool _keepCountingDown = true;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = Object.FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _remainingTime = 60;
        _keepCountingDown = true;
    }

    public void StartTimer()
    {
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (_keepCountingDown)
        {
            yield return new WaitForSeconds(1f);

            if (_remainingTime <= 10)
            {
                timerText.text = "0" + _remainingTime.ToString();
                timerText.fontStyle = FontStyle.Bold;
            }
            else
            {
                timerText.text = _remainingTime.ToString();
                timerText.fontStyle = FontStyle.Normal;
            }

            if (_remainingTime <= 0)
            {
                _keepCountingDown = false;
                timerText.fontStyle = FontStyle.Bold;
                timerText.text = "00";
                _gameManager.EndTheGame();
            }

            _remainingTime--;
        }
    }
}