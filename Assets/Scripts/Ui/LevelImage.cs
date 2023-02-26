using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelImage : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _spriteLock;
    [SerializeField] private Save _save;

    private int _indexLevel;

    public void SetLevel(int indexLevel)
    {
        _indexLevel = indexLevel;
        _text.text = _indexLevel.ToString();

        if (_save.IsFirstPassLevel(_indexLevel - 1) == false || _indexLevel == 1)
        {
            _spriteLock.SetActive(false);
            _button.interactable= true;
        }
        else
        {
            _spriteLock.SetActive(true);
            _button.interactable= false;
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
        SceneManager.LoadScene(_indexLevel.ToString());
    }
}
