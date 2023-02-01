using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeChangeColor : MonoBehaviour
{
    private Renderer _renderer;
    
    private Color _startColor, _endColor;

    [SerializeField] private float colorChangeDuration = 2f;
    [SerializeField] private float pauseBeforeNewColorChange = 2f;
    private float _recoll;
    private bool _shouldChangeColor=true;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        GenerateNewColor();
    }

    private void Update()
    {
        if (_shouldChangeColor)
        {
            _recoll += Time.deltaTime;
            
            var progress = _recoll / colorChangeDuration;
            var newColor = Color.Lerp(_startColor, _endColor, progress);
            _renderer.material.color = newColor;
            
            if (_recoll>=colorChangeDuration)
            {
                _shouldChangeColor = false;
                ChangeColor();
            }
        }
    }

    private void ChangeColor()
    {
        StartCoroutine(nameof(_ChangeColorCo));
    }

    private IEnumerator _ChangeColorCo()
    {
        yield return new WaitForSeconds(pauseBeforeNewColorChange);
        
        _recoll = 0;
        _shouldChangeColor = true;
        
        GenerateNewColor();
    }
    
    private void GenerateNewColor()
    {
        _startColor = _renderer.material.color;
        _endColor = Random.ColorHSV(0f, 1f, 0.5f, 1f, 1f, 1f);
    }
}
