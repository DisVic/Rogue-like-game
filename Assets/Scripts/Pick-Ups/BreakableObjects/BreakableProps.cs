using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableProps : MonoBehaviour
{
    [SerializeField] private float hp;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0) { BreakObject(); }
    }

    private void BreakObject() => Destroy(gameObject);
}