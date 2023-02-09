using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    [SerializeField] private int lifeTime = 8;
    private void Start()
    {
        Destroy(gameObject,lifeTime);
    }
}
