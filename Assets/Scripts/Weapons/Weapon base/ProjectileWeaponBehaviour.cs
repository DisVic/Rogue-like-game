using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    [SerializeField] protected float lifetimeOfProjectile;
    [SerializeField] protected WeaponScriptableObject weaponData;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    private void Awake()
    {
        SetCurrentProjectileWeaponStats();
    }
    protected virtual void Start()
    {
        Destroy(gameObject, lifetimeOfProjectile);
    }

    public void CheckDirection(Vector3 dir)
    {
        direction = dir;
        float dirx=direction.x;
        float diry=direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirx<0 && diry == 0)//left
        {
            scale.x *= -1;
            scale.y *= -1;
        }
        else if(dirx==0 && diry < 0) { scale.y *= -1;} //down
        else if(dirx==0 && diry > 0) { scale.x *= -1;}//up
        else if(dirx>0 && diry<0) { rotation.z = -90f; }//right down
        else if(dirx>0 && diry > 0) { rotation.z = 0f; }//right up
        else if(dirx<0 && diry > 0)//left down
        {
            scale.x *= -1;
            scale.y*= -1;
            rotation.z = -90f;
        }
        else if(dirx<0 && diry < 0)//left up
        {
            scale.x *= -1;
            scale.y *= -1;
            rotation.z = 0f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void SetCurrentProjectileWeaponStats()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
            ReducePierce();
        }
        else if (collision.CompareTag("Prop"))
        {
            if(collision.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage);
                ReducePierce();
            }
        }
    }

    private void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0) { Destroy(gameObject); }
    }
}
