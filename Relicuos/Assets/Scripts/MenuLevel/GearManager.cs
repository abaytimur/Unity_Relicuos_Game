using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    public int speed = 30;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * (speed * Time.deltaTime));
    }
}