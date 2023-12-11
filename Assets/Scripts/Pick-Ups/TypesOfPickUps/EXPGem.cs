using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPGem : MonoBehaviour, ICollactible
{
    [SerializeField] private int expGranted;
    public void Collect()
    {
        LevelSystem level = FindObjectOfType<LevelSystem>();
        level.IncreaseEXP(expGranted);
        Destroy(gameObject);
    }
}
