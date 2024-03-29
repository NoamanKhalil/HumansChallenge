﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Handles score
//Handles UI
public class GameManager : MonoBehaviour
{

    [SerializeField]
    private int Score;
    [SerializeField]
    private Text scoreText;

    public static GameManager instance { get; private set; }

    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + Score;
    }

    //callback to add score
    public void addScore()
    {
        Score ++;
    }

    //saves score
    public void saveScore()
    {
        //TODO:save score , comapre score and check if its higher and save it 

        int tempScore = PlayerPrefs.GetInt("highestScore");
        if (Score >tempScore)
        {
            PlayerPrefs.SetInt("highestScore", Score);
        }

    }
}
