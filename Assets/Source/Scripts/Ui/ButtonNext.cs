using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Source.Scripts.Ui
{
    [RequireComponent(typeof(Button))]
    public class ButtonNext : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            if (SceneManager.sceneCountInBuildSettings - 1 == SceneManager.GetActiveScene().buildIndex)
            {
                _button.transition = Selectable.Transition.ColorTint;
                _button.interactable = false;
            }
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Next);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Next);
        }

        private void Next()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}