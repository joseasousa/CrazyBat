﻿using UnityEngine;
using System.Collections;

public class BlinkBehavior : MonoBehaviour
{
    public float rateBlink;
    public float currentRateBlink;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentRateBlink += Time.deltaTime;

        if (currentRateBlink > rateBlink)
        {
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
            currentRateBlink = 0;
        }
    }
}