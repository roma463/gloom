using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private playerRobot _player;
    private bool _isPlayer;

    private void Start()
    {
        _player = playerRobot.ItsPlayer;
    }
    void Update()
    {
        if (_isPlayer)
        {
            var pos = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
            transform.Translate(Vector2.up * pos);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            print("yes");
            _isPlayer = true;
            _player.gameObject.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            print("no");
            _isPlayer = false;
            _player.gameObject.transform.parent = null;
        }
    }
}
