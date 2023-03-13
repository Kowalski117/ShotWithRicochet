using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _noAmmo;
    [SerializeField] private int _numberCoinsEnemy;
    [SerializeField] private int _numberCoinsItem;
    [SerializeField] private int _rewardIsLess;

    private int _maxBullets = 1;
    private Player _player;
    private int _coins;
    private int _numberBrokenBullets = 0;
    private int _allEnemy = 0;
    private int _allItem = 0;
    private bool _isLevelPassed;

    public int Coins => _coins;
    public int MaxBullets => _maxBullets;

    public int AllEnemy => _allEnemy;
    public int AllItem => _allItem;

    public event UnityAction BulletCrashed;
    public event UnityAction CoinAdded;

    private void Awake()
    {
        foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
        {
            _allEnemy++;
            _maxBullets += enemy.Health;
        }

        foreach (Item item in GetComponentsInChildren<Item>())
        {
            _allItem++;
            _maxBullets += item.Health;
        }

        _player = GetComponentInChildren<Player>();
        _player.SetBullets(_maxBullets);
    }

    private void Start()
    {
        _isLevelPassed = Save.IsLevelPassed();
        _coins = 0;
    }

    private void OnEnable()
    {
        foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
        {
            enemy.EnemyDied += SubtractEnemy;
            enemy.BulletHit += BulletBroke;
        }

        foreach (Item item in GetComponentsInChildren<Item>())
        {
            item.ItemDied += SubtractItem;
            item.BulletHit += BulletBroke;
        }

        foreach (Wall wall in GetComponentsInChildren<Wall>())
            wall.BulletCrashed += BulletBroke;
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
        {
            enemy.EnemyDied -= SubtractEnemy;
            enemy.BulletHit -= BulletBroke;
        }

        foreach (Item item in GetComponentsInChildren<Item>())
        {
            item.ItemDied += SubtractItem;
            item.BulletHit -= BulletBroke;
        }

        foreach (Wall wall in GetComponentsInChildren<Wall>())
            wall.BulletCrashed -= BulletBroke;
    }

    private void SubtractEnemy()
    {
        _allEnemy--;
        StartCoroutine(Slowmo());

        if (_isLevelPassed)
            _coins += (_numberCoinsEnemy / _rewardIsLess);
        else
            _coins += _numberCoinsEnemy;

        if (_allEnemy <= 0)
            EndGame();
        else
            BulletBroke();

        CoinAdded?.Invoke();
    }

    private void SubtractItem()
    {
        _allItem--;
        StartCoroutine(Slowmo());

        if (_isLevelPassed)
            _coins += (_numberCoinsItem / _rewardIsLess);
        else
            _coins += _numberCoinsItem;

        BulletBroke();
        CoinAdded?.Invoke();
    }

    private void BulletBroke()
    {
        _numberBrokenBullets++;
        BulletCrashed?.Invoke();

        if (_numberBrokenBullets >= _maxBullets)
            EndGame();
    }

    private void EndGame()
    {
        if (_allEnemy <= 0)
        {
            _win.SetActive(true);
            _player.Win();
            SaveIs();
        }
        else
        {
            _noAmmo.SetActive(true);
        }
    }

    IEnumerator Slowmo()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0.6f;
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 1;
    }

    private void SaveIs()
    {
        int coins;
        coins = _coins + Save.Coins();
        Save.LevelStats(coins, true);
    }
}
