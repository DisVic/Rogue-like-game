using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    [Header("Weapon stats")]
    [SerializeField] private WeaponScriptableObject weaponData;
    public WeaponScriptableObject WeaponData { get => weaponData; }
    protected float currentCooldown;

    protected PlayerMovement playerMovement;
    protected virtual void Start()
    {
        playerMovement= FindObjectOfType<PlayerMovement>();
        StartCooldown();
    }

    protected virtual void Update()
    {
        CheckCooldown();
    }

    protected void StartCooldown() => currentCooldown = weaponData.CooldownDuration;
    protected void CheckCooldown()
    {
        currentCooldown-=Time.deltaTime;
        if(currentCooldown <= 0f) 
            Attack();
    }

    protected virtual void Attack() => currentCooldown = weaponData.CooldownDuration;

}
