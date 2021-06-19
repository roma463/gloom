using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modul : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;
    private bool isVisible;
    [SerializeField] private CinemachineVirtualCamera _camera;

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (_camera.m_Lens.OrthographicSize < _collider.size.x)
            {
                _camera.m_Lens.OrthographicSize += Time.deltaTime;
            }
        }
        
    }
    private void OnBecameVisible()
    {
        print("so good");
        isVisible = true;
    }
    private void OnBecameInvisible()
    {
        print("no so good");
        isVisible = false;
    }
}
