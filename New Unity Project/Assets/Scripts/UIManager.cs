using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOver;
    public GameObject player;
    AudioSource bgAudio;
    public Text scoreT;
    public ScoreManager scoreM;
    

    // Start is called before the first frame update
    void Start()
    {
        bgAudio = player.GetComponent<AudioSource>();
        Time.timeScale = 1;
        bgAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseMenu()
    {
        pausePanel.SetActive(true);
        bgAudio.Stop();
        Time.timeScale = 0;
    }

    public void DisablePauseMenu()
    {
        pausePanel.SetActive(false);
        bgAudio.Play();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        bgAudio.Stop();
        Time.timeScale = 0;
        scoreT.text = scoreM.score.ToString();

    }
}
