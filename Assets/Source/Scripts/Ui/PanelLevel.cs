using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Ui
{
    public class PanelLevel : MonoBehaviour
    {
        [SerializeField] private GameObject _level;
        [SerializeField] private GameObject _levelGroup;
        [SerializeField] private int _firstLevelGroup;

        private void Start()
        {
            for (int i = _firstLevelGroup; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                var level = Instantiate(_level, _levelGroup.transform);
                level.GetComponent<LevelImage>().SetLevel(i);
            }
        }
    }
}