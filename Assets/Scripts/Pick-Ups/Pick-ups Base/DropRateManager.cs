using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    private class Drops
    {
        public string name;
        public GameObject item;
        public float dropRate;
    }

    [SerializeField] private List<Drops> drops;

    private void OnDestroy()
    {
        float random = Random.Range(0f, 100f);
        List<Drops> possibleDrop = new List<Drops> ();

        foreach(Drops rate in drops)
        {
            if(random <= rate.dropRate) 
                possibleDrop.Add(rate); 
        }
        if(possibleDrop.Count > 0)
        {
            Drops drops = possibleDrop[Random.Range(0, possibleDrop.Count)];
            Instantiate(drops.item, transform.position, Quaternion.identity);
        }
    }
}
