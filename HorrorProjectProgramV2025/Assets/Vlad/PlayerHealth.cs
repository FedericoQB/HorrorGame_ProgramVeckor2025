using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float health = 1f;
    public float maxHealth = 1f;

    public GameObject HealthBarDamageSprite;
    public Image healthBar;
    public BoxCollider2D playerBoxCollider2D;

    private void Start()
    {
        if (HealthBarDamageSprite == null)
        {
            Debug.LogWarning("No GameObject HealthBarDamageSprite was attached to PlayerHealth script");
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            health = 0f;
            print("Nah bro, u ded!");
        }
        healthBar.fillAmount = health;
    }

    public void damagePlayer(float amount)
    {
        try
        {
            HealthBarDamageSprite.SetActive(true);
        }
        catch
        {
            // Nothing
        }
        
        health -= amount;
        if (health <= 0f)
        {
            health = 0f;
            print("Nah bro, u ded!");
        }
    }

    public void healPlayer(float amount)
    {
        try
        {
            HealthBarDamageSprite.SetActive(false);
        }
        catch
        {
            // Nothing
        }
        health += amount;
        if (health >= 1f)
        {
            health = 1f;
        }
    }
}
