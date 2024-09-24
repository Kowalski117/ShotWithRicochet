using Agava.YandexGames;
using Source.Scripts.Ui;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Source.Scripts
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject _win;
        [SerializeField] private GameObject _noAmmo;
        [SerializeField] private int _numberCoinsEnemy;
        [SerializeField] private int _numberCoinsItem;
        [SerializeField] private int _rewardIsLess;
        [SerializeField] private Button _addBullet;
        [SerializeField] private MixerSetting _mixer;

        private Player.Player _player;
        private int _maxBullets = 1;
        private int _coins;
        private int _numberBrokenBullets = 0;
        private int _allEnemy = 0;
        private int _allItem = 0;
        private bool _isLevelPassed;
        private int _star = 0;
        private int _healthEnemy = 0;
        private int _healthItem = 0;

        public event UnityAction BulletCrashed;
        public event UnityAction CoinAdded;
        public event UnityAction BulletAdded;

        public int Coins => _coins;
        public int MaxBullets => _maxBullets;
        public int AllEnemy => _allEnemy;
        public int AllItem => _allItem;
        public int Star => _star;

        private void Awake()
        {
            foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
            {
                _allEnemy++;
                _maxBullets += enemy.Health;
                _healthEnemy += enemy.Health;
            }

            foreach (Item item in GetComponentsInChildren<Item>())
            {
                _allItem++;
                _maxBullets += item.Health;
                _healthItem += item.Health;
            }

            _player = GetComponentInChildren<Player.Player>();
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
                enemy.BulletHitting += BulletBroke;
            }

            foreach (Item item in GetComponentsInChildren<Item>())
            {
                item.ItemDied += SubtractItem;
                item.BulletHitting += BulletBroke;
            }

            foreach (Wall wall in GetComponentsInChildren<Wall>())
                wall.BulletCrashed += BulletBroke;

            _addBullet.onClick.AddListener(ShowAd);
        }

        private void OnDisable()
        {
            foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
            {
                enemy.EnemyDied -= SubtractEnemy;
                enemy.BulletHitting -= BulletBroke;
            }

            foreach (Item item in GetComponentsInChildren<Item>())
            {
                item.ItemDied += SubtractItem;
                item.BulletHitting -= BulletBroke;
            }

            foreach (Wall wall in GetComponentsInChildren<Wall>())
                wall.BulletCrashed -= BulletBroke;

            _addBullet.onClick.RemoveListener(ShowAd);
        }

        private void AddBullet()
        {
            int value = 1;
            _maxBullets++;
            BulletAdded?.Invoke();
            _player.SetBullets(value);
            _noAmmo.SetActive(false);
        }

        private void SubtractEnemy()
        {
            _allEnemy--;

            if (_isLevelPassed)
                _coins += _numberCoinsEnemy / _rewardIsLess;
            else
                _coins += _numberCoinsEnemy;

            BulletBroke();
            CoinAdded?.Invoke();
        }

        private void SubtractItem()
        {
            _allItem--;

            if (_isLevelPassed)
                _coins += _numberCoinsItem / _rewardIsLess;
            else
                _coins += _numberCoinsItem;

            BulletBroke();
            CoinAdded?.Invoke();
        }

        private void BulletBroke()
        {
            _numberBrokenBullets++;
            BulletCrashed?.Invoke();

            if (_numberBrokenBullets >= _maxBullets || _allEnemy <= 0)
                EndGame();
        }

        private void EndGame()
        {
            if (_allEnemy <= 0)
            {
                CountStar();
                _win.SetActive(true);
                _player.Win();
                SaveIs();
            }
            else
            {
                _noAmmo.SetActive(true);
            }
        }

        private void CountStar()
        {
            if (_healthEnemy == _numberBrokenBullets)
            {
                _star = 3;
            }
            else if (_healthEnemy + _healthItem >= _numberBrokenBullets)
            {
                _star = 2;
            }
            else
            {
                _star = 1;
            }
        }

        private void SaveIs()
        {
            int coins;
            coins = _coins + Save.GetCoins();
            Save.LevelStats(coins, true, _star);
        }

        private void ShowAd()
        {
            VideoAd.Show(() => _mixer.Mute(), AddBullet, () => _mixer.Load(), null);
        }
    }
}