using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.Ui
{
    [RequireComponent(typeof(Button))]

    public class AutorizatoinButton : MonoBehaviour
    {
        [SerializeField] private Button _buttonClose;
        
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Authorize);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Authorize);
        }
        private void Authorize()
        {
            PlayerAccount.Authorize();
            _buttonClose.onClick.Invoke();
        }
    }
}