using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TrueFalseManager : MonoBehaviour
{
    [SerializeField] private GameObject trueImage, falseImage;
    
    // Start is called before the first frame update
    void Start()
    {
        MakeLocalScaleZero();
    }

    public void TrueFalseImagesLocalScaleAdjuster(bool isItTrue)
    {
        if (isItTrue)
        {
            trueImage.GetComponent<RectTransform>().DOScale(1, 0.2f);
            falseImage.GetComponent<RectTransform>().localScale= Vector3.zero;
        }
        else
        {
            falseImage.GetComponent<RectTransform>().DOScale(1, 0.2f);
            trueImage.GetComponent<RectTransform>().localScale= Vector3.zero;
        }
        Invoke(nameof(MakeLocalScaleZero), 0.4f);
    }

    void MakeLocalScaleZero()
    {
        trueImage.GetComponent<RectTransform>().localScale= Vector3.zero;
        falseImage.GetComponent<RectTransform>().localScale= Vector3.zero;
    }
}
