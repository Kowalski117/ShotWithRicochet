using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NewGame : MonoBehaviour
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
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
