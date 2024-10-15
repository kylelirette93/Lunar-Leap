using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject pausePanel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pausePanel.SetActive(false);
    }
    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Level01");
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeClicked()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }

}
