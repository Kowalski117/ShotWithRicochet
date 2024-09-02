using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.Ui
{
    [RequireComponent(typeof(Button))]

    public class ButtonClose : MonoBehaviour
    {
        private GameObject _parent;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _parent = transform.parent.gameObject;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            _parent.gameObject.SetActive(false);
        }
    }
}