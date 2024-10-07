using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    int playerHealth = 60;
    const int damage = 20;
    bool playerIsDead = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            TakeDamage(damage);
        }
    }
    public void TakeDamage(int damage)
    {
        if (playerHealth <= 0)
        {
            playerIsDead = true;
            Die();
        }
    }

    
    void Die()
    {
        if (playerIsDead)
        {
            SceneManager.LoadScene(1);
        }
    }
}
