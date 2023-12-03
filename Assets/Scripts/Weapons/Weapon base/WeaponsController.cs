using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    [Header("Weapon stats")]
    [SerializeField] protected GameObject weapon;
    [SerializeField] protected float cooldownDuration;
    protected float currentCooldown;
    [SerializeField] protected float speed;
    public float Speed {  get { return speed; } }
    [SerializeField] protected float damage;
    public float Damage { get { return speed; } }
    
    [SerializeField] protected int pierce;
    public int Pierce {  get { return pierce; } }

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

    protected void StartCooldown() => currentCooldown = cooldownDuration;
    protected void CheckCooldown()
    {
        currentCooldown-=Time.deltaTime;
        if(currentCooldown <= 0f) {Attack();}
    }

    protected virtual void Attack() => currentCooldown = cooldownDuration;

}
