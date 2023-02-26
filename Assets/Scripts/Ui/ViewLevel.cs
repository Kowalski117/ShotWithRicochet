using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewLevel : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsLevel;
    [SerializeField] private Level _level;
    [SerializeField] private Player _player;
    [SerializeField] private ViewBullets _viewBullets;
    [SerializeField] private Button _settings;

    private void Start()
    {
        _coinsLevel.text = _level.Coins.ToString();
        _viewBullets.CreateBullets(_level.MaxBullets);
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

        _coinsLevel.text = _coinsLevel.text = _level.Coins.ToString();
    }

    private void UpdateBullets()
    {
        _viewBullets.ChangeImage();
    }
}
