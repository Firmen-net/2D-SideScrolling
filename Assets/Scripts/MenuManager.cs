using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameoverPanel;
    public GameObject finishedPanel;
    public GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
    }

    public void StartGame()
    {
        player.SetActive(true);
        startPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameoverPanel.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}