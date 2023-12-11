using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private HeroScriptableObject heroData;

    private float currentHP;
    private float currentMP;
    private float currentSpeed;
    private float currentRecovery;
    private float currentProjectileSpeed;

    

    [Header("I-Frames")]
    [SerializeField] private float invincibilityDuration;
    private float invincibilityTimer;
    private bool isInvincible;

    private void Awake()
    {
        SetCurrnetHeroStats();
    }

    private void Update()
    {
        CheckInvincibleTimer();
    }

    private void SetCurrnetHeroStats()
    {
        currentHP = heroData.MaxHealth;
        currentMP = heroData.Might;
        currentSpeed = heroData.MoveSpeed;
        currentRecovery = heroData.Recovery;
        currentProjectileSpeed = heroData.ProjectileSpeed;
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            currentHP -= damage;
            invincibilityTimer = invincibilityDuration;
            isInvincible = true;
            if (currentHP <= 0) 
                Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void CheckInvincibleTimer()
    {
        if (invincibilityTimer > 0)
            invincibilityTimer -= Time.deltaTime;
        else 
            isInvincible = false;
    }

    public void RestoreHP(float amount)
    {
        if (currentHP < heroData.MaxHealth)
        {
            currentHP += amount;
            if (currentHP > heroData.MaxHealth) 
                currentHP = heroData.MaxHealth;            
        }
    }
}
