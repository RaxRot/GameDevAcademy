using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] pointsToFollow;
    private int _currentIndex;

    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private float waitTimeBeforeChangePoint;

    private bool _canMove = true;

    private void Update()
    {
        Patroll();
    }

    private void Patroll()
    {
        if (_canMove)
        {
            transform.position = Vector3.Lerp(transform.position, pointsToFollow[_currentIndex].position,
                moveSpeed * Time.deltaTime);
        }
        
        if (Vector3.Distance(transform.position,pointsToFollow[_currentIndex].position)<=0.1f)
        {
            _canMove = false;
            
            ResetPoint();
            
            _currentIndex++;
            if (_currentIndex>=pointsToFollow.Length)
            {
                _currentIndex=0;
            }
        }
    }

    private void ResetPoint()
    {
        StartCoroutine(nameof(_ResetPointCo));
    }

    private IEnumerator _ResetPointCo()
    {
        yield return new WaitForSeconds(waitTimeBeforeChangePoint);
        _canMove = true;
    }
}
