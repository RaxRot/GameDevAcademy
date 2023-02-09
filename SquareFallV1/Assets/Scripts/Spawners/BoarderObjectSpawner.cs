using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoarderObjectSpawner : MonoBehaviour
{
    
    [SerializeField] private Transform leftPosition, rightPosition;
    [SerializeField] private GameObject leftCube, rightCube;

    [SerializeField] private float minTimeBetweenSpawn, maxTimeBetweenSpawn;
    private float _timeBetweenSpawn;
    
    
    public void SpawnObject()
    {
        StartCoroutine(nameof(_SpawnObjectCo));
    }

    private IEnumerator _SpawnObjectCo()
    {
        if (GameManager.Instance.IsGamePlaying)
        {
            _timeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
            yield return new WaitForSeconds(_timeBetweenSpawn);

            if (Random.Range(0,2)==0)
            {
                Instantiate(leftCube, leftPosition.position, Quaternion.identity);
           
            }
            else
            {
                Instantiate(rightCube, rightPosition.position, Quaternion.identity);
            }
            
            StartCoroutine(nameof(_SpawnObjectCo));
        }
    }
}
