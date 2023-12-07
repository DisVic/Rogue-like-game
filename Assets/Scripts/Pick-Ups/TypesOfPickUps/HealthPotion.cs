using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollactible
{ 
    [SerializeField] private int healthRestoration;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.RestoreHP(healthRestoration);
        Destroy(gameObject);
    }
}
