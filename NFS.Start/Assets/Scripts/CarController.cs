using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float moveSpeed = 6f;
    private float _forwardSpeed;
    private float _turnSpeed;

    private string _horizontalAxis = "Horizontal";
    private  string _forwardAxis = "Vertical";

    private float _xAxis, _zAxis;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       ControllInput();
    }

    private void ControllInput()
    {
        MoveUpDown();

        MoveLeftRight();
    }

    private void FixedUpdate()
    {
        MoveCar();
    }

    private void MoveCar()
    {
        _rb.velocity = new Vector3(_turnSpeed, _rb.velocity.y, _forwardSpeed);
    }

    private void MoveUpDown()
    {
        _zAxis = Input.GetAxisRaw(_forwardAxis);
        if (_zAxis>0)
        {
            _forwardSpeed = moveSpeed;
        }else if (_zAxis<0)
        {
            _forwardSpeed = moveSpeed * -1;
        }
        else
        {
            _forwardSpeed = 0;
        }
    }

    private void MoveLeftRight()
    {
        _xAxis = Input.GetAxisRaw(_horizontalAxis);
        
        if (_xAxis>0 && _zAxis!=0)
        {
            _turnSpeed = _xAxis*3f;
        }else if (_xAxis<0 && _zAxis!=0)
        {
            _turnSpeed = _xAxis*3f;
        }
        else
        {
            _turnSpeed = 0;
        }
    }
}
