using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    private MapController mapController;
    [SerializeField] private GameObject targetMap;
    private void Start()
    {
        mapController = FindObjectOfType<MapController>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            mapController.currentChunk = targetMap;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(mapController.currentChunk == targetMap)  
                mapController.currentChunk = null; 
        }
    }
}
