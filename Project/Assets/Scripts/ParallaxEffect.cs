using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _parallax;

    private float _startPosX;
    private float _startPosY;
    private float _lenght;

    private void Start()
    {
        _startPosX = transform.position.x;
        _startPosY = transform.position.y;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = _camera.position.x * (1 - _parallax);
        float distX = _camera.position.x * _parallax;
        float distY = _camera.position.y * (1 - _parallax);

        transform.position = new Vector2(_startPosX + distX, _startPosY + distY);

        if(temp > _startPosX + _lenght)
        {
            _startPosX += _lenght;
        }
        else if(temp < _startPosX - _lenght)
        {
            _startPosX -= _lenght;
        }
    }
}
