using System;
using Agava.YandexGames;
using Source.Scripts.Ui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts
{
    public class AddCoins : MonoBehaviour
    {
        [SerializeField] private int _coin;
        [SerializeField] private Button _button;
        [SerializeField] private MixerSetting _mixer;
        [SerializeField] private int _maxAmountUse;
        [SerializeField] private TMP_Text _textAttempts;
        [SerializeField] private TMP_Text _textButtonCoins;
        [SerializeField] private TMP_Text _textCoins;

        private int _leftToGet;
        private int _saveDay;
        private int _currentDay;
    
        private void OnEnable()
        {
            _saveDay = Save.GetDayUsedGift();
            _leftToGet = Save.GetLeftToGetGift();
            _currentDay = DateTime.Today.Day;

            if (_currentDay > _saveDay)
            {
                _leftToGet = _maxAmountUse;
                Save.SetDayUsedGift(_currentDay);
                Save.SetLeftToGetGift(_leftToGet);
            }

            _button.onClick.AddListener(ShowAd);
            View();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ShowAd);
        }

        private void View()
        {        
            if (_leftToGet == 0)
                _button.gameObject.SetActive(false);
            
            _textAttempts.text = $"{_leftToGet}/{_maxAmountUse}";
            _textButtonCoins.text = $"+{_coin}";
        }

        private void AddCoin()
        {
            _leftToGet--;
            Save.SetCoins(Save.GetCoins()+_coin);
            Save.SetLeftToGetGift(_leftToGet);
            _textCoins.text = Save.GetCoins().ToString();
            gameObject.SetActive(false);
        }
    
        private void ShowAd()
        {
            VideoAd.Show(() => _mixer.Mute(), AddCoin, () => _mixer.Load(), null);
        }
    }
}