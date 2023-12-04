using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject",menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{

    [SerializeField] private float moveSpeed;
    public float MoveSpeed {  get => moveSpeed; }
    [SerializeField] private float damage;
    public float Damage { get => damage; }
    [SerializeField] private float maxHealth;
    public float MaxHealth { get => maxHealth; }
}
