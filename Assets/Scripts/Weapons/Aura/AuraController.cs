using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraController : WeaponsController
{

    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedAura = Instantiate(weapon);
        spawnedAura.transform.position = transform.position;
        spawnedAura.transform.parent = transform;
    }
}
