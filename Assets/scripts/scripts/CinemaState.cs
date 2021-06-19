using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemaState : MonoBehaviour
{
    public enum State
    {
        global,
        localPlayer,
        localModul,
    }

    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private AnimationCurve _sizeCamera;
    [SerializeField] private float _speed;
    private Transform _player => playerRobot.ItsPlayer.transform;
    private float size = 16;
    private float timeCerve;
    private void Start()
    {
        timeCerve = _sizeCamera.keys[_sizeCamera.keys.Length - 1].time;
    }
    //private void Update()
    //{
    //    if (_camera.m_Lens.OrthographicSize <= size
    //        && Input.GetKey(KeyCode.V))
    //    _camera.m_Lens.OrthographicSize += Time.deltaTime * 20;
    //}
    public void CinemaNewState(State state)
    {
        if(state == State.global)
        {
            SizeCinema(_player, 16);
        }
        else if (state == State.localModul)
        {

        }
        else
        {

        }
    }
    private void mobul()
    {
        
    }
    private void SizeCinema(Transform follow, float size = 16f)
    {
        //_camera.Follow = follow;
        //StartCoroutine(nameof(ChangesSize()));
        StartCoroutine("ChangesSize");
    }

}
