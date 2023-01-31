using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject carForSpawn;
    [SerializeField] private Transform positionForSpawn;

    private void Start()
    {
        SetValues();
    }

    private void SetValues()
    {
        Instantiate(carForSpawn, positionForSpawn.position, Quaternion.identity);
        
        CameraController.Instance.FindPlayer();
    }
}
