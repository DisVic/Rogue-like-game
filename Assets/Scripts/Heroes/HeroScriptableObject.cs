using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroScriptableObject", menuName = "ScriptableObjects/Hero")]
public class HeroScriptableObject : ScriptableObject
{

    [SerializeField] private GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; }

    [SerializeField] private float maxHealth;
    public float MaxHealth { get => maxHealth; }

    [SerializeField] private float recovery;
    public float Recovery { get => recovery; }

    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get => moveSpeed;}

    [SerializeField] private float might;
    public float Might { get => might; }

    [SerializeField] private float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed;}
}
