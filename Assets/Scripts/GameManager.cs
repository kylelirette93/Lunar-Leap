using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting.FullSerializer.Internal;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject pausePanel;
    public GameObject controlsPanel;
    public Image[] lives;
    public int remainingLives = 3;
    public GameObject player;
    Vector3 originalPosition;
    bool controlsDisplayed = false;

    private void Awake()
    {
        instance = this;
        if (player != null)
        {
            originalPosition = player.transform.position;
        }
        else
        {
            Debug.Log("Player is either null or not needed for scene.");
        }
    }

    private void Start()
    {
        pausePanel.SetActive(false);
        player = GameObject.Find("Player");
    }


    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Level01");
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }

    public void MainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
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
        if (remainingLives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (SceneManager.GetActiveScene().buildIndex == 1 && !controlsDisplayed)
        {
            DisplayControls();
        }
    }

    void DisplayControls()
    {
        controlsPanel.SetActive(true);
    }

    public void ExitControls()
    {
        controlsDisplayed = true;
        controlsPanel.SetActive(false);
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

    public void PlayAgainClicked()
    {
        SceneManager.LoadScene(PlayerHealth.lastBuildIndex);
    }


    public void LoseLife()
    {
        remainingLives--;
        player.transform.position = originalPosition;
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        playerRB.velocity = Vector3.zero;
        lives[remainingLives].enabled = false;
    }

}
