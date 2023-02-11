using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [HideInInspector]
    public static float score;
    public Text scoreText;

    private int scoreToNextLevel = 20;
    private int maxDifficultyLevel = 20;
    private int difficultyLevel = 1;
    public Text highScore;


    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= scoreToNextLevel)
        {
            LevelUp();
        }

        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
        if((int)score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            //highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
            highScore.text = ((int)score).ToString();
        }
    }

    void LevelUp()
    {
        if(difficultyLevel == maxDifficultyLevel)
        {
            return;
        }

        scoreToNextLevel *= 2;
        difficultyLevel++;
        
        GetComponent<BallMovement>().SetSpeed(difficultyLevel);
    }
}
