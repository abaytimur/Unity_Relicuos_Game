using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform startButton;
    [SerializeField] private Transform gameLogo;

    [SerializeField] private Animator startButtonAnimator;
    
    [SerializeField] private AudioClip slidingSound;
    private AudioSource _audioSource;
    private static readonly int StartAnimation = Animator.StringToHash("startAnimation");

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        _audioSource.PlayOneShot(slidingSound);
        gameLogo.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        Invoke(nameof(HeadImageAnimation), 0.5f);
        Invoke(nameof(StartButtonAnimation), 1f);
    }

    private void HeadImageAnimation()
    {
        _audioSource.PlayOneShot(slidingSound);
        head.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
    }

    private void StartButtonAnimation()
    {
        _audioSource.PlayOneShot(slidingSound);
        startButton.transform.GetComponent<RectTransform>().DOLocalMoveY(-270F, 1F).SetEase(Ease.OutBack);
        
        Invoke(nameof(WaitForStartButtonAnimation),1.5f);
    }

    private void WaitForStartButtonAnimation()
    {
        startButtonAnimator.SetBool(StartAnimation, true);
    }
    
    public void StartButtonPressed()
    {
        // _audioSource.PlayOneShot(startButtonSound);
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        // startButton.transform.GetComponent<RectTransform>().DOLocalMoveY(-506F, 1F).SetEase(Ease.OutBack);
        yield return null;
        SceneManager.LoadScene("GameLevel");
    }
}