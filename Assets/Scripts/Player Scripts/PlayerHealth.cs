using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Variables
    const int maxHealth = 100;
    int currentHealth;
    const int damage = 20;
    bool playerIsDead = false;
    public static int lastBuildIndex;
    public bool canDie = true;

    // References
    public HealthBar healthBar;
    public TextMeshProUGUI healthText;
    string bubbleTag = "Bubble";

    private void Start()
    {
        // Set the player's current health to max at the start.
        currentHealth = maxHealth;

        SetHealthText();

        // Fill the health bar slider.
        healthBar.SetHealthBarMax(maxHealth);

        lastBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Laser"))
        {
            if (canDie)
            {
                TakeDamage(damage);
            }
            else
            {
                GameObject bubble = GameObject.FindWithTag(bubbleTag);
                Destroy(bubble);
                canDie = true;
            }
        
        }
    }
    public void TakeDamage(int dmg)
    {
        // Decrement damage from current health and set the health bar to current health.
        currentHealth -= dmg;

        // Update the health text.
        SetHealthText();

        // Update the health bar.
        healthBar.SetHealthBar(currentHealth);

        if (currentHealth <= 0)
        {
            playerIsDead = true;
            Die();
        }
    }

    void SetHealthText()
    {
        // Set the health text to current health.
        healthText.text = "Health: " + currentHealth.ToString();
    }

    

    void Die()
    {
        if (playerIsDead)
        {
            GameManager.instance.LoseLife();
        }
    }
}
