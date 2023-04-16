using System;
using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

public class Rating : MonoBehaviour
{
    [SerializeField] private Button _buttonRating;
    [SerializeField] private GameObject _authorization;
    [SerializeField] private GameObject _leaderBoard;

    private void OnEnable()
    {
        _buttonRating.onClick.AddListener(CheckAuthorization);
    }

    private void OnDisable()
    {
        _buttonRating.onClick.RemoveListener(CheckAuthorization);
    }

    private void CheckAuthorization()
    {
        if (PlayerAccount.IsAuthorized)
        {
            _leaderBoard.SetActive(true);
        }
        else
        {
            _authorization.SetActive(true);
        }
    }
}
