using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private ParticleSystem _crash;
    [SerializeField] private ParticleSystem _coins;
    [SerializeField] private List<GameObject> _loots;

    public event UnityAction ItemDied;
    public event UnityAction BulletHit;

    public int Health => _health;

    private void Start()
    {
        _health = 1;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Death();
        }
        else
        {
            BulletHit?.Invoke();
        }
    }

    private void Death()
    {
        Instantiate(_crash, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Instantiate(_coins, transform.position + new Vector3(0, 1, 0), Quaternion.identity);

        foreach (var item in _loots)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
        ItemDied?.Invoke();
    }
}
