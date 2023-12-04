using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehaviour : ProjectileWeaponBehaviour
{

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        CheckSpearPosition();
    }
    public void CheckSpearPosition() => transform.position += direction * weaponData.Speed * Time.deltaTime;
}
