using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IIEnemy : MonoBehaviour
{
    [SerializeField] private point[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private point _thisPoint;

    private void Start()
    {
        _thisPoint = Choise();
    }
    private void Update()
    {
        if (_thisPoint == null)
            return;
        transform.position = Vector2.MoveTowards(transform.position, _thisPoint.transform.position, _speed * Time.deltaTime);
        if(transform.position == _thisPoint.transform.position)
        {
            _thisPoint = Choise();
        }
    }
    private point Choise()
    {
        if (_thisPoint != null)
            return _thisPoint.GetPoint();
        else
            return _points[0];
    }
}
