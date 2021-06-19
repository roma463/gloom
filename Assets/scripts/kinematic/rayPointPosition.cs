using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayPointPosition : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _point;
    private void Update()
    {
        var hit = RayCast();
       _point.position = hit.point;
    }
    private RaycastHit2D RayCast()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, _layerMask);
    }
}
