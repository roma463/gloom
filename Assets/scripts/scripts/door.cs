using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animationPosition;
    [SerializeField] private float _speed;
    private float _countTimeAnimation;
    private Vector2 position;

    void Start()
    {
        position = transform.position;
        _countTimeAnimation = _animationPosition.keys[_animationPosition.keys.Length - 1].time;
        StartCoroutine(nameof(Animation));
    }
    public IEnumerator Animation()
    {
        for(float x = 0; x < _countTimeAnimation; x += Time.deltaTime)
        {
            position.y += _animationPosition.Evaluate(x) * _speed * Time.deltaTime;
            transform.position = position;
            yield return null;
        }
    }
}
