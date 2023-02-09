using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy,score;
    
    [SerializeField] private float xSpawnRange = 2f;

    [SerializeField] private float timeBetweenSpawn;
    private Vector2 _spawnPos;

    [SerializeField] private float percentToSpawnScore;
    

    public void SpawnObject()
    {
        StartCoroutine(_SpawnObjectCo());
    }

    private IEnumerator _SpawnObjectCo()
    {
        if (GameManager.Instance.IsGamePlaying)
        {
            _spawnPos = transform.position;
            _spawnPos.x = Random.Range(-xSpawnRange, xSpawnRange);

            Instantiate(Random.Range(0, 100) > percentToSpawnScore ? enemy : score, _spawnPos, Quaternion.identity);
        
            yield return new WaitForSeconds(timeBetweenSpawn);
            
            StartCoroutine(_SpawnObjectCo());
        }
    }
}
