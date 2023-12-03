using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehaviour : ProjectileWeaponBehaviour
{
    private SpearController spearController;

    protected override void Start()
    {
        base.Start();
        spearController = FindObjectOfType<SpearController>();
    }

    private void Update()
    {
        CheckSpearPosition();
    }
    public void CheckSpearPosition() => transform.position += direction * spearController.Speed * Time.deltaTime;
}
