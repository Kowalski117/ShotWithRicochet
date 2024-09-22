using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Source.Scripts.Ui
{
    public class LevelImage : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _spriteLock;
        [SerializeField] private Sprite _goldStar;
        [SerializeField] private List<GameObject> _stars;

        private int _indexLevel;

        public void SetLevel(int indexLevel)
        {
            _indexLevel = indexLevel;

            if (Save.IsLevelPassed(_indexLevel - 1) == true || _indexLevel == 1)
            {
                _spriteLock.SetActive(false);
                _text.text = _indexLevel.ToString();
                _button.interactable = true;
                StarChangeSprite();
            }
            else
            {
                _spriteLock.SetActive(true);
                _text.text = null;
                _button.interactable = false;
            }
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(LoadLevel);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(LoadLevel);
        }

        private void LoadLevel()
        {
            SceneManager.LoadScene(_indexLevel);
        }

        private void StarChangeSprite()
        {
            for (int i = 0; i < Save.GetStarsLevel(_indexLevel); i++)
            {
                _stars[i].GetComponent<Image>().sprite = _goldStar;
            }
        }
    }
}