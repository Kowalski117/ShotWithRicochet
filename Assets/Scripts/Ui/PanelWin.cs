using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelWin : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private TMP_Text _banditText;
    [SerializeField] private TMP_Text _boxText;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _buttonSkip;
    [SerializeField] private CameraPosition _cameraPosition;
    [SerializeField] private Level _level;
    [SerializeField] private Sprite _starGold;
    [SerializeField] private List<GameObject> _stars;

    private void Start()
    {
        _game.SetActive(false);
        _win.SetActive(true);
        _panel.SetActive(false);
        _cameraPosition.PositionWin();
    }

    private void OnEnable()
    {
        _buttonSkip.onClick.AddListener(Skip);
    }

    private void OnDisable()
    {
        _buttonSkip.onClick.RemoveListener(Skip);
    }

    private void Skip()
    {
        StarChangeSprite();
        _buttonSkip.gameObject.SetActive(false);
        _panel.SetActive(true);
        _coinText.text = _level.Coins.ToString();
        _banditText.text = _level.AllEnemy.ToString();
        _boxText.text = _level.AllItem.ToString();
    }

    private void StarChangeSprite()
    {
        for (int i = 0; i < _level.Star; i++)
        {
            _stars[i].GetComponent<Image>().sprite = _starGold;
        }
    }
}