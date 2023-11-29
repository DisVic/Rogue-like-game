using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    [SerializeField]List<GameObject> propSpawnPoint;
    [SerializeField]List<GameObject> propPrefabs;

    void Start()
    {
        SpawnProp();   
    }
    void SpawnProp()
    {
        foreach (GameObject props in propSpawnPoint) 
        {
            int random=Random.Range(0, propPrefabs.Count);
            GameObject prop = Instantiate(propPrefabs[random],props.transform.position,Quaternion.identity);
            prop.transform.parent = props.transform;
        }
    }

}
