using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Transform filling;

    private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealthBar(float health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth);
        float fillAmount = currentHealth / maxHealth;

        if (filling != null)
        {
            filling.localScale = new Vector3(fillAmount, filling.localScale.y, filling.localScale.z);
        }

        if (currentHealth == 0)
        {
            HandleDeath();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        UpdateHealthBar(currentHealth);
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        UpdateHealthBar(currentHealth);
    }

    public void HandleDeath()
    {
        if (CompareTag("Player"))
        {
            Debug.Log("Player's health dropped to 0!");
            SceneManager.LoadScene(2);
        }
        else if (CompareTag("Enemy"))
        {
            Debug.Log("Enemy's health dropped to 0!");
        }

        Destroy(gameObject);
    }
}