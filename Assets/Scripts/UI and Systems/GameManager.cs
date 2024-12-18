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

    // References.
    public GameObject pausePanel;
    public GameObject controlsPanel;
    public PlayerHealth playerHealth;
    public Image[] lives;
    public GameObject player;
    public GameObject cursorLock;
    Vector3 originalPosition;

    // Variables.
    public int remainingLives = 3;
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
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        else
        {
            Debug.Log("Pause panel is null or not needed for this scene.");
        }
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }


    public void PlayButtonClicked()
    {
        // Loads first level from main menu.
        SceneManager.LoadScene("Level01");
    }

    public void ExitButtonClicked()
    {
        // Quit the game from any menu with an X.
        Application.Quit();
    }

    public void MainMenuClicked()
    {
        // Return to main menu.
        SceneManager.LoadScene("MainMenu");
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
            // Only display the controls if we're on the first level.
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
        cursorLock.SetActive(true);
    }
    void PauseGame()
    {
        // Stop time and activate pause menu.
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeClicked()
    {
        // Resume time and deactivate pause menu.
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }

    public void PlayAgainClicked()
    {
        // From the game over menu, load the last scene we were in, this index value is stored in player health on death.
        SceneManager.LoadScene(PlayerHealth.lastBuildIndex);
    }


    public void LoseLife()
    {
        // Lose a life, reset player's position and velocity.
        // Get rid of a life from UI.
        remainingLives--;
        player.transform.position = originalPosition;
        playerHealth.Revive();
        playerHealth.SetHealthText();
        playerHealth.healthBar.SetHealthBarMax(playerHealth.currentHealth);
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        playerRB.velocity = Vector3.zero;
        playerRB.angularVelocity = Vector3.zero;
        lives[remainingLives].enabled = false;
    }
}
