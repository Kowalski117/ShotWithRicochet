using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Save))]
public class Level : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _noAmmo;
    [SerializeField] private int _numberCoinsItemAndEnemy;

    private Save _save;
    private Player _player;
    private int _coins;
    private int _numberBrokenBullets = 0;
    private int _maxBullets;
    private int _allItemAndEnemy = 0;
    private bool _isFirstPassLevel;

    public int Coins => _coins;
    public int MaxBullets => _maxBullets;

    public event UnityAction BulletCrashed;
    public event UnityAction CoinAdded;

    private void Awake()
    {
        foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
            _allItemAndEnemy++;

        foreach (Item item in GetComponentsInChildren<Item>())
            _allItemAndEnemy++;
    }

    private void Start()
    {
        _maxBullets = _allItemAndEnemy;
        _save = GetComponent<Save>();
        _player = GetComponentInChildren<Player>();
        _player.GetBullets(_maxBullets);
        _isFirstPassLevel = _save.IsFirstPassLevel();
        _coins = 0;
    }

    private void OnEnable()
    {
        foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
            enemy.EnemyDied += SubtractItemAndEnemy;

        foreach (Item item in GetComponentsInChildren<Item>())
            item.ItemDied += SubtractItemAndEnemy;

        foreach (Wall wall in GetComponentsInChildren<Wall>())
            wall.BulletCrashed += BulletBroke;
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
            enemy.EnemyDied -= SubtractItemAndEnemy;

        foreach (Item item in GetComponentsInChildren<Item>())
            item.ItemDied += SubtractItemAndEnemy;

        foreach (Wall wall in GetComponentsInChildren<Wall>())
            wall.BulletCrashed -= BulletBroke;
    }

    private void SubtractItemAndEnemy()
    {
        _allItemAndEnemy--;

        if (_isFirstPassLevel)
            _coins += _numberCoinsItemAndEnemy;
        else
            _coins += (_numberCoinsItemAndEnemy/10);

        if (_allItemAndEnemy <= 0)
            EndGame();
        else
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
        if (_allItemAndEnemy <= 0)
        {
            _win.SetActive(true);
            Save();
        }
        else
        {
            _noAmmo.SetActive(true);
        }
    }

    private void Save()
    {
        int coins;
        coins = _coins + _save.Coins();
        Debug.Log(_coins);
        Debug.Log(_save.Coins());
        Debug.Log(coins);
        _save.LevelStats(coins, true);
    }
}
