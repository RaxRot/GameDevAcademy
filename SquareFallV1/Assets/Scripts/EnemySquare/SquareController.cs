using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float minRotationPower, maxRotationPower;
    private float _rotationPower;
    
    [SerializeField] private float minMoveSpeed = 2f, maxMoveSpeed = 3.5f;
    private float _moveSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
       SetValues();
    }

    private void SetValues()
    {
        _rotationPower = Random.Range(minRotationPower, maxRotationPower);
        
        _rotationPower=Random.Range(0,2)==0?_rotationPower:_rotationPower*-1;

        _moveSpeed = Random.Range(minMoveSpeed,maxMoveSpeed);
    }

    private void FixedUpdate()
    {
        _rb.rotation += _rotationPower;
        _rb.velocity = Vector2.down * _moveSpeed;
    }
}
