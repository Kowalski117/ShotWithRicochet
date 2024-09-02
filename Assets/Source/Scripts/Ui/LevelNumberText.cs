using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Ui
{
    public class LevelNumberText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private void Start()
        {
            _text.text = SceneManager.GetActiveScene().buildIndex.ToString();
        }
    }
}