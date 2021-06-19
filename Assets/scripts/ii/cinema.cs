using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cinema : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private AnimationCurve _shaking;
    private Vector3 position, rotation;
    private void Start()
    {
        rotation = transform.eulerAngles;
        position = transform.position;
    }
    public float move(float time)
    {
        //transform.position = new Vector3(position.x + _shaking.Evaluate(time) * _speed, position.y, -10);
        transform.rotation = Quaternion.Euler(0, 0, rotation.z + _shaking.Evaluate(time) * _speed * Time.deltaTime);
        if(time >= 1)
        {
            transform.rotation = Quaternion.Euler(rotation);
            return 0f;
        }
        return time + Time.deltaTime;
    }
}
