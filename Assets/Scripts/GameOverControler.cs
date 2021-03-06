﻿using UnityEngine;
using System.Collections;

public class GameOverControler : MonoBehaviour
{

    public TextMesh score;
    public TextMesh bestScore;
    public Renderer[] medals;

    public GameObject content;
    public GameObject title;

    public GameObject newScore;

    void Start()
    {
        HideGameOver();
    }


    void Update()
    {

    }

    public void SetGameOver(int scoreIngame)
    {

        if (scoreIngame > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", scoreIngame);
            newScore.SetActive(true);
        }
        else
        {
            newScore.SetActive(false);
        }

        score.text = scoreIngame.ToString();
        bestScore.text = PlayerPrefs.GetInt("Score").ToString();

        if (scoreIngame > 70)
        {
            medals[0].enabled = true;
        }
        else if (scoreIngame > 35)
        {
            medals[1].enabled = true;
        }
        else 
        {
            medals[2].enabled = true;
        }
        content.SetActive(true);
        title.SetActive(true);
    }

    
    public void HideGameOver()
    {
        content.SetActive(false);
        title.SetActive(false);
        foreach (Renderer m in medals)
        {
            m.enabled = false;
        }
    }
}
