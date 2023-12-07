using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private List<GameObject> terrainChunks = new List<GameObject>(); 
    [SerializeField] private GameObject player;
    [SerializeField] private float checkerRadius;
    private Vector3 notTerrainPosition;
    [SerializeField] private LayerMask terrain;
    [HideInInspector] public GameObject currentChunk;
    private PlayerMovement playerMovement;

    [Header("Optimization")]
    private List<GameObject> spawnedChunks;
    private GameObject latestChunk;
    [SerializeField]private float maxOptimizationDistance;
    private float optimizationDistance;
    private float optimizerCooldown;
    [SerializeField] private float optimizerCooldownDuration;
    private void Start()
    {
        playerMovement=FindObjectOfType<PlayerMovement>();
    }
    private void Update()
    {
        CheckChunk();
        OptimizeChunk();
    }

    private void CheckChunk()//переделать
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
    private void SpawnChunk()
    {
        int random = Random.Range(0,terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[random], notTerrainPosition,Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    private void OptimizeChunk()//в отдельный класс
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
