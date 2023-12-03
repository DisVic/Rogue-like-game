using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    [SerializeField] protected float lifetimeOfMelee;
    protected virtual void Start()
    {
        Destroy(gameObject, lifetimeOfMelee);
    }


}
