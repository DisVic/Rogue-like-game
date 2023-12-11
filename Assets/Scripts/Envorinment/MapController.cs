using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private List<GameObject> terrainChunks; 
    [SerializeField] private GameObject player;
    [SerializeField] private float checkerRadius;
    [SerializeField] private LayerMask terrain;
    [HideInInspector] public GameObject currentChunk;
    private PlayerMovement playerMovement;
    private void Start()
    {
        playerMovement=FindObjectOfType<PlayerMovement>();
    }
    private void Update()
    {
        CheckChunk();
    }

    private void CheckChunk()//переделать
    {
        if (!currentChunk) return;
        if(playerMovement.Direction.x>0 && playerMovement.Direction.y == 0) //right
        {
            SpawnChunk("Right");
        }    
        else if (playerMovement.Direction.x < 0 && playerMovement.Direction.y == 0) //left
        {
            SpawnChunk("Left");
        }
        else if (playerMovement.Direction.x == 0 && playerMovement.Direction.y > 0) //up
        {
            SpawnChunk("Up");
        }    
        else if (playerMovement.Direction.x == 0 && playerMovement.Direction.y < 0) //down
        {
            SpawnChunk("Down");
        }
        else if (playerMovement.Direction.x < 0 && playerMovement.Direction.y < 0) //left down
        {
            SpawnChunk("Left down");
        }
        else if (playerMovement.Direction.x > 0 && playerMovement.Direction.y > 0) //right up
        {
            SpawnChunk("Right up");
        }
        else if (playerMovement.Direction.x < 0 && playerMovement.Direction.y > 0) //left up
        {
            SpawnChunk("Left up");
        }
        else if (playerMovement.Direction.x > 0 && playerMovement.Direction.y < 0) //right down
        {
            SpawnChunk("Right down");
        }
    }
    private void SpawnChunk(string name)
    {
        if (Physics2D.OverlapCircle(currentChunk.transform.Find(name).position, checkerRadius, terrain)) return;

        Vector3 notTerrainPosition = currentChunk.transform.Find(name).position;
        int random = Random.Range(0,terrainChunks.Count);
        Instantiate(terrainChunks[random], notTerrainPosition,Quaternion.identity);
    }
}
