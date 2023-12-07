using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    [SerializeField] private EnemyScriptableObject enemyData;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        MoveToPlayer();
    }
        
    private void MoveToPlayer()// переделать
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            player.transform.position, enemyData.MoveSpeed * Time.deltaTime);
    }
        
}
