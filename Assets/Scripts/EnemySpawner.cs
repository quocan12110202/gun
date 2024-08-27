using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public float SpawnRate = 1.5f;
    public float SpawnRadius = 5f;
    private float SpawnTimer = 0f;
    void Start()
    {
        
    }
    void Update()
    {
        if (!GameManager.Instance.GameOver())
        {


            SpawnTimer += Time.deltaTime;
            if (SpawnTimer >= SpawnRate)
            {
                SpawnEnemy();
                SpawnTimer = 0f;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, SpawnRadius);
    }
    void SpawnEnemy()
    {
        Vector2 randomPosition = (Vector2)transform.position+Random.insideUnitCircle.normalized * SpawnRadius;
        Instantiate(enemyPrefabs, randomPosition, Quaternion.identity);
    }
}
