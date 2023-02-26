using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _healh;
    [SerializeField] private int _damage;
    [SerializeField] private int _speed;
    [SerializeField] private ParticleSystem _hittingWall;
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            Instantiate(_hittingWall, transform.position, transform.rotation);
            Vector3 newDirection = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            transform.rotation = Quaternion.LookRotation(newDirection);
            _healh--;

            if (_healh <= 0)
            {
                collision.gameObject.GetComponent<Wall>().BulletBroke();
                Death();
            }
        }

        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
            Death();
        }

        if (collision.gameObject.GetComponent<Item>())
        {
            collision.gameObject.GetComponent<Item>().TakeDamage(_damage);
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
