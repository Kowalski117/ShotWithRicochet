using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private ParticleSystem _death;
    [SerializeField] private ParticleSystem _coins;
    [SerializeField] private List<GameObject> _loots;

    public event UnityAction EnemyDied;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        EnemyDied?.Invoke();
        Instantiate(_death, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Instantiate(_coins, transform.position + new Vector3(0, 1, 0), Quaternion.identity);

        foreach (var item in _loots)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
