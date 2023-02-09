using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoarderSquareController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float minMoveForce=1.25f,maxMoveForce=2.25f;
    private float _moveForce;
    
    [SerializeField] private float minRotationPower, maxRotationPower;
    private float _rotationPower;

    [SerializeField] private bool moveRight;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetValues();
    }

    private void FixedUpdate()
    {
        _rb.rotation += _rotationPower;
    }

    private void SetValues()
    {
        _moveForce = Random.Range(minMoveForce, maxMoveForce);
        
        _rotationPower = Random.Range(minRotationPower, maxRotationPower);
        _rotationPower=Random.Range(0,2)==0?_rotationPower:_rotationPower*-1;

        PushIntoLeft(!moveRight);
    }

    private void PushIntoLeft(bool moveLeft)
    {
        if (moveLeft)
        {
            _rb.AddForce(Vector3.left*_moveForce,ForceMode2D.Impulse);
        }
        else
        {
            _rb.AddForce(Vector3.right*_moveForce,ForceMode2D.Impulse);
        }
    }
}
