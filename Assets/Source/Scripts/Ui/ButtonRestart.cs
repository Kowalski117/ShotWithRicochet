using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Source.Scripts.Ui
{
    [RequireComponent(typeof(Button))]

    public class ButtonRestart : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Restart);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Restart);
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}