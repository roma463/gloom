using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legControl : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Transform _point;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _speed;
    [SerializeField] private  spiderControl _speedPlayer;
    private Vector2 _pos;
    private bool isMoved = true;

    private void Start()
    {
        _pos = transform.position;
        transform.position = _pos;
    }

    private void Update()
    {
        transform.position = _pos;
        if (Vector2.Distance(_point.position, transform.position) > _radius)
        {
            transform.position = _point.position;
            _pos =transform.position;
            isMoved = true;
        }

        //if (hit)
        //{
        //    _point.position = hit.point;
        //    if(Vector2.Distance(_point.position, transform.position) > _radius)
        //    {
        //        transform.position = _point.position;
        //        _pos = _point.position;
        //        isMoved = true;
        //    }
        //    else if(!isMoved)
        //    {
        //        transform.position = _pos;
        //    }
        //}
    }

}
