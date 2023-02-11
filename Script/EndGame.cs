using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject GameOverPanel;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    void Update()
    {
        
    }
    void GameOver()
    {
        if(player == null)
        {
            GameOverPanel.SetActive(true);
        }
    }
}
