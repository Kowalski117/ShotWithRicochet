using Agava.YandexGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class AdCoinButton : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private MixerSetting _mixer;
    private Button _button;
    private int _coinLevel;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ShowAd);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(ShowAd);
    }

    private void AddCoin()
    {
        int coin;
        _coinLevel = _level.Coins;
        coin = Save.GetCoins() + _coinLevel;
        Save.SetCoins(coin);
        _coinLevel += _coinLevel;
        _coinText.text = _coinLevel.ToString();
        _button.interactable = false;
    }
    
    private void ShowAd()
    {
        VideoAd.Show(() => _mixer.Mute(), AddCoin, () => _mixer.Load(), null);
    }
}
