using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] List<GameObject> terrainChunks;
    [SerializeField] GameObject player;
    [SerializeField] float checkerRadius;
    Vector3 notTerrainPosition;
    [SerializeField] LayerMask terrain;
    [HideInInspector] public GameObject currentChunk;
    PlayerMovement playerMovement;

    [Header("Optimization")]
    [SerializeField] List<GameObject> spawnedChunks;
    GameObject latestChunk;
    [SerializeField]float maxOptimizationDistance;
    float optimizationDistance;
    float optimizerCooldown;
    [SerializeField] float optimizerCooldownDuration;
    void Start()
    {
        playerMovement=FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        CheckChunk();
        OptimizeChunk();
    }

    void CheckChunk()
    {
        if (!currentChunk) return;
        if(playerMovement.Direction.x>0 && playerMovement.Direction.y == 0) //right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrain))
            {
                notTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }    
        else if (playerMovement.Direction.x < 0 && playerMovement.Direction.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrain))
            {
                notTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.Direction.x == 0 && playerMovement.Direction.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrain))
            {
                notTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }    
        else if (playerMovement.Direction.x == 0 && playerMovement.Direction.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrain))
            {
                notTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.Direction.x < 0 && playerMovement.Direction.y < 0) //left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left down").position, checkerRadius, terrain))
            {
                notTerrainPosition = currentChunk.transform.Find("Left down").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.Direction.x > 0 && playerMovement.Direction.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right up").position, checkerRadius, terrain))
            {
                notTerrainPosition = currentChunk.transform.Find("Right up").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.Direction.x < 0 && playerMovement.Direction.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left up").position, checkerRadius, terrain))
            {
                notTerrainPosition = currentChunk.transform.Find("Left up").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.Direction.x > 0 && playerMovement.Direction.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right down").position, checkerRadius, terrain))
            {
                notTerrainPosition = currentChunk.transform.Find("Right down").position;
                SpawnChunk();
            }
        }
    }
    void SpawnChunk()
    {
        int random = Random.Range(0,terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[random], notTerrainPosition,Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    void OptimizeChunk()
    {
        optimizerCooldown -= Time.deltaTime;
        if (optimizerCooldown <= 0f)
            optimizerCooldown = optimizerCooldownDuration;
        else
            return;
        foreach (GameObject chunk in spawnedChunks)
        {
            optimizationDistance=Vector3.Distance(player.transform.position, chunk.transform.position);
            if(optimizationDistance > maxOptimizationDistance) 
                chunk.SetActive(false);
            else
                chunk.SetActive(true);
        }
    }
}
