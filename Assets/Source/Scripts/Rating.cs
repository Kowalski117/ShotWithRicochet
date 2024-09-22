using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts
{
    public class Rating : MonoBehaviour
    {
        [SerializeField] private Button _buttonRating;
        [SerializeField] private GameObject _authorization;
        [SerializeField] private GameObject _leaderBoard;

        private bool _isAutorized;

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
            StartCoroutine(CheckWorkSDK());
        }

        private void OpenPanel()
        {
            if (_isAutorized)
            {
                _leaderBoard.SetActive(true);
            }
            else
            {
                _authorization.SetActive(true);
            }
        }

        private IEnumerator CheckWorkSDK()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            yield break;
#endif
            if (!YandexGamesSdk.IsInitialized)
                yield return YandexGamesSdk.Initialize();
            _isAutorized = PlayerAccount.IsAuthorized;
            OpenPanel();
        }
    }
}