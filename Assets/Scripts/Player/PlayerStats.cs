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

    [Header("Exp/level")]
    [SerializeField] private int exp = 0;
    [SerializeField] private int level = 1;
    [SerializeField] private int experienceCap;

    [System.Serializable]
    private class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    [SerializeField] private List<LevelRange> levelRanges;

    [Header("I-Frames")]
    [SerializeField] private float invincibilityDuration;
    private float invincibilityTimer;
    private bool isInvincible;

    private void Awake()
    {
        SetCurrnetHeroStats();
    }

    private void Start()
    {
        InitializeEXPCap();
    }

    private void Update()
    {
        CheckInvincibleTimer();
    }

    private void InitializeEXPCap() => experienceCap = levelRanges[0].experienceCapIncrease;

    public void IncreaseEXP(int amount)
    {
        exp += amount;
        CheckLevel();
    }

    private void CheckLevel()
    {
        if (exp >= experienceCap)
        {
            level++;
            exp -= experienceCap;

            int experienceCapIncrease = 0;
            foreach(LevelRange range in levelRanges)
            {
                if(level>=range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;
        }
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
            if (currentHP <= 0) { Die(); }
        }
    }

    private void Die() => Destroy(gameObject);

    private void CheckInvincibleTimer()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else { isInvincible = false; }
    }

    public void RestoreHP(float amount)
    {
        if (currentHP < heroData.MaxHealth)
        {
            currentHP += amount;
            if (currentHP > heroData.MaxHealth) { currentHP = heroData.MaxHealth; }
        }
    }
}
