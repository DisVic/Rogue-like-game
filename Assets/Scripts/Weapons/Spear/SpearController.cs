using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : WeaponsController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSpear = Instantiate(WeaponData.Weapon);
        spawnedSpear.transform.position = transform.position;
        spawnedSpear.GetComponent<SpearBehaviour>().CheckDirection(playerMovement.LastMovedVector);
    }
}
