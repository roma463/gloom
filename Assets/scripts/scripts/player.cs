using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
[SerializeField] private float _speed;
[SerializeField] private float _jumpForce;
[SerializeField] private Rigidbody2D _rigidbody;
[SerializeField] private Animator _animator;
[SerializeField] private ParticleSystem _collision;

   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _animator.SetTrigger("UpJump");
        }

    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _animator.SetTrigger("jump");
            _collision.Play();
        }
    }
    
}
