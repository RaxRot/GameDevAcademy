using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    [SerializeField] private Vector3 offset = new Vector3(0, 2.5f, -3.5f);
    private bool _shouldFollow;

    private Transform _targetToFollow;

    private Vector3 _temp;

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }

    private void LateUpdate()
    {
        if (!_shouldFollow)
        {
            return;
        }
        
        FollowPlayer();
    }

    public void FindPlayer()
    {
        _targetToFollow = FindObjectOfType<CarController>().transform;
        _shouldFollow = true;
    }

    private void FollowPlayer()
    {
        _temp = _targetToFollow.position;
        _temp += offset;

        transform.position = _temp;
    }
}
