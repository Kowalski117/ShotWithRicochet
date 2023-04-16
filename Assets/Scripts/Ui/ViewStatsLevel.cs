using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewStatsLevel : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsLevel;
    [SerializeField] private Level _level;
    [SerializeField] private TMP_Text _valueEnemy;
    [SerializeField] private TMP_Text _valueItem;
    
    private void Start()
    {
        _coinsLevel.text = _level.Coins.ToString();
        ChangeStats();
    }

    private void OnEnable()
    {
        _level.CoinAdded += ChangeStats;
    }

    private void OnDisable()
    {
        _level.CoinAdded -= ChangeStats;
    }

    private void ChangeStats()
    {
        _coinsLevel.text =_level.Coins.ToString();
        _valueEnemy.text = _level.AllEnemy.ToString();
        _valueItem.text = _level.AllItem.ToString();
    }
}
