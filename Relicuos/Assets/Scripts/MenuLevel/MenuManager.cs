using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform startButton;

    // Start is called before the first frame update
    void Start()
    {
        head.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        Invoke(nameof(StartButtonAnimation), 0.5f);
    }

    private void StartButtonAnimation()
    {
        startButton.transform.GetComponent<RectTransform>().DOLocalMoveY(-270F, 1F).SetEase(Ease.OutBack);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameLevel");
    }
}