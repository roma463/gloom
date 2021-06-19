using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animCube;
    private bool _onClick = true;
    
    private void OnMouseDown()
    {
        if(_onClick)
        StartCoroutine(nameof(noup));
    }
    private IEnumerator noup()
    {
        _onClick = false;
        for (float i = 0; i < 1; i+= Time.deltaTime)
        {
            transform.localScale = Vector3.one * _animCube.Evaluate(i);
            yield return null;
        }
        transform.localScale = Vector3.one * _animCube.Evaluate(1);
        _onClick = true;
    }
}
