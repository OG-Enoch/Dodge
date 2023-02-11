using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseMenu;
    public GameObject pauseMenuObj;
    public GameObject pausePanel;
    public GameObject pauseButton;
    public new AudioSource audio;

    void Start()
    {
        pausePanel.SetActive(false);
        //pauseMenuObj.SetActive(false);
        pauseMenu.transform.localScale = new Vector3(0, 0, 0);
    }
    public void Open()
    {
        //pauseMenu.transform.LeanScale(Vector2.one, 1f).setEaseOutBack();
        LeanTween.scale(pauseMenuObj, new Vector3(1, 1, 1), 0.8f).setEaseInBack();
        //pauseMenuObj.SetActive(true);
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        audio.volume = 0.2f;
        Time.timeScale = 0;
    }
    public void Close()
    {
        pauseMenu.transform.LeanScale(Vector2.zero, 0.8f);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    } 
}
