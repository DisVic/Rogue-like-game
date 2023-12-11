using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [Header("Exp/level")]
    [SerializeField] private int exp = 0;
    [SerializeField] private int level = 1;
    [SerializeField] private int experienceCap;

    [System.Serializable]
    private class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    [SerializeField] private List<LevelRange> levelRanges;
    private void Start()
    {
        InitializeEXPCap();
    }

    private void InitializeEXPCap() => experienceCap = levelRanges[0].experienceCapIncrease;
    public void IncreaseEXP(int amount)
    {
        exp += amount;
        CheckLevel();
    }

    private void CheckLevel()
    {
        if (exp < experienceCap) return;
        else
        {
            level++;
            exp -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }
}
