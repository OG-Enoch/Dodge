using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    public float restartTime;
    public GameObject gameOverPanel;
    public Animator gameOverAnim;
    public GameObject score;
    public GameObject PauseButton;
    public GameObject highScore;
    public GameObject highScoreText;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    void Update()
    {
        StartCoroutine(Restart());
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator Restart()
    {
        if(player == null)
        {   
            highScore.SetActive(false);
            highScoreText.SetActive(false);
            score.SetActive(false);
            PauseButton.SetActive(false);
            StartCoroutine(GameOver());
            yield return new WaitForSeconds(restartTime);
            SceneManager.LoadScene("MainMenu");
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);
        gameOverAnim.SetTrigger("GameOver");
    }
}
