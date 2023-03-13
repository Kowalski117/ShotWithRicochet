using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewLevel : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsLevel;
    [SerializeField] private Level _level;
    [SerializeField] private ViewBullets _viewBullets;
    [SerializeField] private Button _settings;
    [SerializeField] private TMP_Text _valueEnemy;
    [SerializeField] private TMP_Text _valueItem;

    private int _coins;

    public int Coins => _coins;

    private void Start()
    {
        _coinsLevel.text = _level.Coins.ToString();
        _viewBullets.CreateBullets(_level.MaxBullets);
        ChangeStats();
    }

    private void OnEnable()
    {
        _level.BulletCrashed += UpdateBullets;
        _level.CoinAdded += UpdateCoins;
    }

    private void OnDisable()
    {
        _level.BulletCrashed -= UpdateBullets;
        _level.CoinAdded -= UpdateCoins;
    }

    private void UpdateCoins()
    {
        _coins = _level.Coins;
        _coinsLevel.text =_coins.ToString();
        ChangeStats();
    }

    private void UpdateBullets()
    {
        _viewBullets.ChangeImage();
    }

    private void ChangeStats()
    {
        _valueEnemy.text = _level.AllEnemy.ToString();
        _valueItem.text = _level.AllItem.ToString();
    }
}
