using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    [SerializeField]private List<GameObject> propSpawnPoint;
    [SerializeField]private List<GameObject> propPrefabs;

    private void Start()
    {
        SpawnProp();   
    }
    private void SpawnProp()
    {
        foreach (GameObject props in propSpawnPoint) 
        {
            int random=Random.Range(0, propPrefabs.Count);
            GameObject prop = Instantiate(propPrefabs[random],props.transform.position,Quaternion.identity);
            prop.transform.parent = props.transform;
        }
    }

}
