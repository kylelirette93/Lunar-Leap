using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject pausePanel;
    public TextMeshProUGUI versionText;
    public static int deathCount = 0;

    private void Awake()
    {
        instance = this;
        versionText.text = "V" + PlayerSettings.bundleVersion;
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
        if (deathCount >= 3)
        {
            deathCount = 0;
            SceneManager.LoadScene("GameOver");
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

    public void PlayAgainClicked()
    {
        SceneManager.LoadScene(PlayerHealth.lastBuildIndex);
    }

}
