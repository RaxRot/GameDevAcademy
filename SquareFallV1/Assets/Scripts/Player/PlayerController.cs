using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float moveSpeed = 8f;
    
    private bool _isMovingLeft;

    [SerializeField] private float switchPoint = 2.25f;

    [SerializeField] private GameObject increaseScoreFx, playerDeadFx;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.Instance.IsGamePlaying)
        {
            MoveBall();
        
            SwitchRootViaKeyBoard();
        }
        else
        {
            _rb.velocity=Vector2.zero;
        }
    }

    private void SwitchRootViaKeyBoard()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.PlaySfx(0);
            
            _isMovingLeft = !_isMovingLeft;
        }
    }

    private void MoveBall()
    {
        _rb.velocity = _isMovingLeft ? new Vector2(-moveSpeed, 0f) : new Vector2(moveSpeed, 0f);
        
        CheckMovePosition();
    }

    private void CheckMovePosition()
    {
        if (transform.position.x<-switchPoint)
        {
            _isMovingLeft = false;
            AudioManager.Instance.PlaySfx(3);
        }else if (transform.position.x>switchPoint)
        {
            _isMovingLeft = true;
            AudioManager.Instance.PlaySfx(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (GameManager.Instance.IsGamePlaying)
        { 
            if (col.CompareTag(TagManager.SCORE_TAG))
            {
                GameManager.Instance.IncreaseScore();

                Instantiate(increaseScoreFx, transform.position, Quaternion.identity);
            }else if (col.CompareTag(TagManager.ENEMY_TAG))
            {
                GameManager.Instance.GameOver();
                
                Instantiate(playerDeadFx, transform.position, Quaternion.identity);
            }
            
            Destroy(col.gameObject);
        }
    }
}
