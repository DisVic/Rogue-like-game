using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject",menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]private GameObject weapon;
    public GameObject Weapon { get => weapon; }
    [SerializeField] private float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; }
    [SerializeField] private float speed;
    public float Speed { get => speed; }
    [SerializeField] private float damage;
    public float Damage { get => damage; }
    [SerializeField] private int pierce;
    public int Pierce { get => pierce; }
}
