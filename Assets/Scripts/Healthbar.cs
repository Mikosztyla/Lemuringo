using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] 
    private Transform filling;

    private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        TakeDamage(100f);
    }

    public void UpdateHealthBar(float health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth);
        float fillAmount = currentHealth / maxHealth;
        
        if (filling != null)
        {
            filling.localScale = new Vector3(fillAmount, filling.localScale.y, filling.localScale.z);
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
}