using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linePosition : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animCube;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    private float _countTime;
    private void Start()
    {
        _countTime = _animCube.keys[_animCube.keys.Length - 1].time;
    }
    private void OnMouseDown()
    {
        StartCoroutine(nameof(pop));
    }
    private IEnumerator pop()
    {
        
        for (float i = 0; i < _countTime; i+= Time.deltaTime)
        {
            _speed = _animCube.Evaluate(i);
            //var pos = transform.position;
            //pos =  Vector2.left * (i * _speed);
            //transform.position = new Vector2(pos.x, transform.position.y);
            _rigidbody.AddForce(Vector2.up * _speed * 10);
            yield return null;
        }
    }
}
