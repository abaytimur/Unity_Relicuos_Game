using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CirclesManager : MonoBehaviour
{
    [SerializeField] private GameObject[] circleSeries;

    // Start is called before the first frame update
    void Start()
    {
        TurnOffCirclesScales();
    }

    public void TurnOffCirclesScales()
    {
        foreach (GameObject circle in circleSeries)
        {
            circle.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }

    public void TurnOnCirclesScales(int whichCircle)
    {
        circleSeries[whichCircle].GetComponent<RectTransform>().DOScale(1, 0.3f);
        if (whichCircle % 5 == 0)
        {
            TurnOffCirclesScales();
        }
    }
}