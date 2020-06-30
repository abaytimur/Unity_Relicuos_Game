using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class CountDownManager : MonoBehaviour
{
    [SerializeField] private GameObject countDownImage;
    [SerializeField] private Text countDownText;
    [SerializeField] private GameObject buttonDisablePanel;
    
    private RectTransform _rectTransform;
    private RectTransform _rectTransform1;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = countDownImage.GetComponent<RectTransform>();
        _rectTransform1 = buttonDisablePanel.GetComponent<RectTransform>();
        StartCoroutine(CountDownRoutine());
    }

    public IEnumerator CountDownRoutine()
    {
        _rectTransform1.DOScale(1, .001f);
            
        countDownText.text = "3";
        // yield return new WaitForSeconds(.4f);

        _rectTransform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(.3f);
        _rectTransform.DOScale(0, 0.3f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(.3f);

        countDownText.text = "2";
        yield return new WaitForSeconds(.3f);

        _rectTransform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(.3f);
        _rectTransform.DOScale(0, 0.3f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(.3f);

        countDownText.text = "1";
        yield return new WaitForSeconds(.4f);

        _rectTransform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(.3f);
        _rectTransform.DOScale(0, 0.3f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(.3f);

        _rectTransform1.DOScale(0, .001f);
        StopAllCoroutines();
    }
}