using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeGeneration : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    
    [SerializeField] private float minXPos, manXPos;
    [SerializeField]private float minYPos, maxYPos;
    [SerializeField]private float minZPos, maxZPos;
    
    private float _xPosition, _yPosition, _zPosition;
    private Vector3 _spawnVector;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        _xPosition = Random.Range(minXPos, manXPos);
        _yPosition = Random.Range(minYPos, maxYPos);
        _zPosition = Random.Range(minZPos, maxZPos);

        _spawnVector = new Vector3(_xPosition, _yPosition, _zPosition);

        Instantiate(cube, _spawnVector, Quaternion.identity);
    }
}
