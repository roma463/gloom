using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leg : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private Transform _LookAtObj;
    private void Update()
    {

        var pos = _point.position - _LookAtObj.position;
        pos.z =  Mathf.Atan2(pos.x, pos.y) * Mathf.Rad2Deg;
        _LookAtObj.rotation = Quaternion.Euler(0,0, -pos.z);
    }
}
