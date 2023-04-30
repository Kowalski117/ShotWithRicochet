using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardPlayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _first;
    [SerializeField] private Sprite _second;
    [SerializeField] private Sprite _third;

    public void SetView(string rank, string name, string score)
    {
        _rank.text = rank;
        _name.text = name;
        _score.text = score;

        switch (rank)
        {
            case "1":
                _image.sprite = _first;
                break;
            case "2":
                _image.sprite = _second;
                break;
            case "3":
                _image.sprite = _third;
                break;

        }
    }
}
