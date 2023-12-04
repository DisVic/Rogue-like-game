using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPGem : MonoBehaviour, ICollactible
{
    [SerializeField] private int expGranted;
    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseEXP(expGranted);
        Destroy(gameObject);
    }
}
