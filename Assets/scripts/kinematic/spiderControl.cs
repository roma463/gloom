using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float InputVelue { private set; get; }
    
   
    void Update()
    {
        InputVelue = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        transform.Translate(Vector2.right * InputVelue);
    }
}
