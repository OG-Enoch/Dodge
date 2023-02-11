using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    Animator pauseAnim;
    public GameObject pauseButton;
    public GameObject pauseMenuPanel;
    public GameObject pauseMenuSound;
    public new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        pauseAnim = GetComponent<Animator>();
    }
    public void Open()
    {   
        pauseAnim.SetTrigger("Open");
        pauseButton.SetActive(false);
        pauseMenuPanel.SetActive(true);
        audio.volume = 0.2f;
        StartCoroutine("StopTime");
        Instantiate(pauseMenuSound, transform.position, Quaternion.identity);   
    }
    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(0.28f);
        Time.timeScale = 0;
    }
    public void Close()
    {
        pauseAnim.SetTrigger("Close");
        pauseButton.SetActive(true);
        pauseMenuPanel.SetActive(false);
        audio.volume = 1f;
        Time.timeScale = 1;
    }
}
