using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IIcinema : MonoBehaviour
{
    
    [SerializeField] private float _angle;
    [SerializeField] private float _distance;
    [SerializeField] private float _speedRotation;
    private playerRobot _player;
    private Vector3 _startRotation;
    private float rotation;

    private void Start()
    {
        _startRotation = transform.eulerAngles;
        _player = playerRobot.ItsPlayer;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < _distance)
        {
            var realAngle = Vector2.Angle(transform.up * -1, _player.transform.position - transform.position);
            var position = transform.position - _player.gameObject.transform.position;
            rotation = Mathf.Atan2(position.x, position.y) * Mathf.Rad2Deg;

            if (_angle / 2 > realAngle)
            {
                transform.rotation = Quaternion.Euler(0, 0, Mathf.MoveTowardsAngle(transform.eulerAngles.z, -rotation, _speedRotation));
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.MoveTowardsAngle(transform.eulerAngles.z, _startRotation.z, _speedRotation));
        }
    }

    private void OnDrawGizmos()
    {
        var ray = new Ray(transform.position, (transform.up*-1));
        Gizmos.DrawRay(ray);
    }
}
