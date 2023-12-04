using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObject enemyData;
    private float currentSpeed;
    private float currentHP;
    private float currentDamage;
    private void Awake()
    {
        SetCurrentEnemyStats();
    }

    private void SetCurrentEnemyStats()
    {
        currentDamage = enemyData.Damage;
        currentHP = enemyData.MaxHealth;
        currentSpeed = enemyData.MoveSpeed;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0) { Die(); }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
