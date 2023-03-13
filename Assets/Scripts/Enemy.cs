using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private ParticleSystem _death;
    [SerializeField] private ParticleSystem _coins;
    [SerializeField] private ParticleSystem _damage;
    [SerializeField] private List<GameObject> _loots;

    private Animator _animator;
    private string _hit = "Hit";

    public event UnityAction EnemyDied;
    public event UnityAction BulletHit;

    public int Health => _health;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        _animator.SetTrigger(_hit);

        if (_health <= 0)
        {
            Death();
        }
        else
        {
            Instantiate(_damage, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
            BulletHit?.Invoke();
        }
    }

    private void Death()
    {
        Instantiate(_death, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Instantiate(_coins, transform.position + new Vector3(0, 1, 0), Quaternion.identity);

        foreach (var item in _loots)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
        EnemyDied?.Invoke(); 
    }
}
